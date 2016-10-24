using Models;
using Models.Sys;
using System.Collections.Generic;
using System.Data;

namespace BLL.Sys
{
	public class DictionaryType
	{
		private readonly static DAL.Sys.DicTypeMapper dicTypeMapper = new DAL.Sys.DicTypeMapper();

		/// <summary>
		/// 查询
		/// </summary>
		/// yaoy    15.12.01
		/// qiy		15.12.04
		/// <param name="typeId"></param>
		/// <returns></returns>
		public DictionaryTypeInfo Get(int typeId)
		{
			return dicTypeMapper.Find(typeId);
		}

		/// <summary>
		/// 列表
		/// qiy		15.12.04
		/// </summary>
		/// <returns></returns>
		public DataTable List()
		{
			return dicTypeMapper.List();
		}

		/// <summary>
		/// 选项
		/// </summary>
		/// yaoy    15.12.01
		/// qiy		15.12.04
		/// <returns></returns>
		public List<ComboInfo> Option()
		{
			return dicTypeMapper.Option();
		}
		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Add(DictionaryTypeInfo value)
		{
			dicTypeMapper.Insert(value);

			return value.TypeId > 0;
		}

		/// <summary>
		/// 修改
		/// </summary>
		/// yaoy    15.12.01
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Modify(DictionaryTypeInfo value)
		{
			var type = Get(value.TypeId);

			if (type == null) return false;

			type.Name = value.Name;
			type.Field = value.Field;
			type.IsCommon = value.IsCommon;

			return dicTypeMapper.Update(type);
		}


		/// <summary>
		/// 获取标识种子
		/// </summary>
		/// qiy		15.12.04
		/// <param name="typeId">类型标识</param>
		/// <returns></returns>
		public int GetSeed(int typeId)
		{
			return Get(typeId).Seed;
		}
		/// <summary>
		/// 设置标识种子
		/// </summary>
		/// qiy		15.12.04
		/// <param name="typeId">类型标识</param>
		/// <param name="seed">种子值</param>
		/// <returns></returns>
		public bool SetSeed(int typeId, int seed)
		{
			var type = Get(typeId);

			if (type == null) return false;

			type.Seed = seed;

			return dicTypeMapper.Update(type);
		}
	}
}
