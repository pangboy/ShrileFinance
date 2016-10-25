using Models;
using Models.Sys;
using System.Collections.Generic;
using System.Web.Http;

namespace Web.Controllers.Sys
{
	public class DictionaryController : ApiController
	{
		private readonly static BLL.Sys.Dictionary _dictionary = new BLL.Sys.Dictionary();
		private readonly static BLL.Sys.DictionaryType _dictionaryType = new BLL.Sys.DictionaryType();

		/// <summary>
		///	查询字典
		/// </summary>
		/// yaoy    15.12.01
		/// qiy		15.12.04
		/// <param name="type">字典类型</param>
		/// <param name="code">字典编号</param>
		/// <returns></returns>
		[HttpGet]
		public DictionaryInfo GetDictionary(int type, byte code)
		{
			return _dictionary.Get(type, code);
		}

		/// <summary>
		/// 字典列表
		/// </summary>
		/// yaoy    15.12.01
		/// qiy		15.12.04
		/// <returns></returns>
		[HttpGet]
		public Datagrid DictionaryList()
		{
			return new Datagrid
			{
				rows = _dictionary.List()
			};
		}
		/// <summary>
		///	查询类型
		/// </summary>
		/// qiy		15.12.04
		/// <param name="typeId">类型标识</param>
		/// <returns></returns>
		[HttpGet]
		public DictionaryTypeInfo GetDictionaryType(int typeId)
		{
			return _dictionaryType.Get(typeId);
		}

		/// <summary>
		/// 类型列表
		/// </summary>
		/// qiy		15.12.04
		/// <returns></returns>
		[HttpGet]
		public Datagrid DictionaryTypeList()
		{
			return new Datagrid
			{
				rows = _dictionaryType.List()
			};
		}

		/// <summary>
		/// 类型选项
		/// </summary>
		/// qiy		15.12.04
		/// <returns></returns>
		[HttpGet]
		public List<ComboInfo> DictionaryTypeOption()
		{
			return _dictionaryType.Option();
		}

		/// <summary>
		/// 添加字典
		/// </summary>
		/// yaoy    15.12.01
		/// qiy		15.12.04
		/// <param name="value"></param>
		/// <returns></returns>
		public IHttpActionResult PostDictionary(DictionaryInfo value)
		{
			string messages;

			return _dictionary.Add(value, out messages) ? (IHttpActionResult)Ok() : BadRequest(messages);
		}

		/// <summary>
		/// 修改字典
		/// </summary>
		/// qiy		15.12.04
		/// <param name="value"></param>
		/// <returns></returns>
		public IHttpActionResult PutDictionary(DictionaryInfo value)
		{
			return _dictionary.Mod(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
		}

		/// <summary>
		/// 添加类型
		/// </summary>
		/// qiy		15.12.04
		/// <param name="value"></param>
		/// <returns></returns>
		public IHttpActionResult PostDictionaryType(DictionaryTypeInfo value)
		{
			return _dictionaryType.Add(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
		}

		/// <summary>
		/// 修改类型
		/// </summary>
		/// qiy		15.12.04
		/// <param name="value"></param>
		/// <returns></returns>
		public IHttpActionResult PutDictionaryType(DictionaryTypeInfo value)
		{
			return _dictionaryType.Modify(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
		}
	}
}
