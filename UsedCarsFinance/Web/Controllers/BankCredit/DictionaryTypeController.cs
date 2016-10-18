using BLL.BankCredit;
using Model;
using Model.BankCredit;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.BankCredit
{
    public class DictionaryTypeController : ApiController
    {
        private readonly static BLL.BankCredit.DictionaryType dictionaryType = new BLL.BankCredit.DictionaryType();

        /// <summary>
        /// 下拉框列表
        /// </summary>
        /// yangj    16.07.04
        /// <param name="dictionaryTypeId">字典类型ID</param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetComList()
        {
            List<ComboInfo> cbi = dictionaryType.GetComList();
            ComboInfo cb = new ComboInfo(string.Empty, "　");
            cbi.Add(cb);
            return cbi;
        }

        /// <summary>
        /// 根据字典类型ID查找记录
        /// </summary>
        /// yangj    16.07.04
        /// <param name="dictionaryTypeId">字典类型ID</param>
        /// <returns></returns>
        [HttpGet]
        public DictionaryTypeInfo GetDictionaryType(int dictionaryTypeId)
        {
            return dictionaryType.Find(dictionaryTypeId);
        }

        /// <summary>
        /// 根据报文ID查找记录列表
        /// </summary>
        /// yangj    16.07.04
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        [HttpGet]
        public Datagrid DictionaryTypeList(int page, int rows)
        {
            Pagination pagination = new Pagination(page, rows);
            NameValueCollection filter = ApiHelper.GetParameters();

            return new Datagrid
            {
                rows = dictionaryType.List(pagination, filter),
                total = pagination.Total
            };
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// yangj    16.07.04
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Modify(DictionaryTypeInfo value)
        {
            return dictionaryType.Modify(value) ? (IHttpActionResult)Ok() : BadRequest("修改失败");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// yangj    16.07.04
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Add(DictionaryTypeInfo value)
        {
            return dictionaryType.Add(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
        }
    }
}
