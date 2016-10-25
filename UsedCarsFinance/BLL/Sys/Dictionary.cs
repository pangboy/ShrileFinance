using Models.Sys;
using System.Data;

namespace BLL.Sys
{
	public class Dictionary
	{
		private readonly static BLL.Sys.DictionaryType _dictionaryType = new DictionaryType();

		private readonly static DAL.Sys.DicCommonMapper dicCommonMapper = new DAL.Sys.DicCommonMapper();

		/// <summary>
		/// 查询字典
		/// </summary>
		/// yaoy    15.12.01
		/// qiy		15.12.04
		/// <param name="type">字典类型</param>
		/// <param name="code">字典编号</param>
		/// <returns></returns>
		public DictionaryInfo Get(int type, int code)
		{
			return dicCommonMapper.Find(type, code);
		}

		/// <summary>
		/// 字典列表
		/// </summary>
		/// yaoy    15.12.01
		/// qiy		15.12.04
		/// <returns></returns>
		public DataTable List()
		{
			return dicCommonMapper.List();
		}

		/// <summary>
		/// 添加
		/// </summary>
		/// yaoy    15.12.01
		/// qiy		15.12.04
		/// <param name="value"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public bool Add(DictionaryInfo value, out string message)
		{
			message = string.Empty;

			if (value.Code.HasValue)
			{
				//指定标识
				if (!CheckSeed(value))
				{
					message = string.Format("字典编号:{0} 已被使用.", value.Code);

					return false;
				}
			}
			else
			{
				//标识按类型自分配
				do
				{
					value.Code = (byte)(_dictionaryType.GetSeed(value.Type) + 1);

					_dictionaryType.SetSeed(value.Type, value.Code.Value);

				} while (!CheckSeed(value));
			}

			dicCommonMapper.Insert(value);

			return true;
		}

		/// <summary>
		/// 检查种子是否已被使用
		/// </summary>
		/// qiy		15.12.07
		/// <param name="value"></param>
		/// <returns></returns>
		private bool CheckSeed(DictionaryInfo value)
		{
			DictionaryInfo dictionary = Get(value.Type, value.Code.Value);

			return dictionary == null ? true : false;
		}

		/// <summary>
		/// 修改
		/// </summary>
		/// yaoy    15.12.01
		/// qiy		15.12.04
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Mod(DictionaryInfo value)
		{
			var dictionary = Get(value.Type, value.Code.Value);

			if (dictionary == null) return false;

			dictionary.Name = value.Name;
			dictionary.Remarks = value.Remarks;

			return dicCommonMapper.Update(dictionary);
		}
	}
}
