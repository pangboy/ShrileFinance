using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using Models.BankCredit;
using System.Collections.Specialized;

namespace Web.Controllers.BankCredit
{
    /// <summary>
    /// DictionaryCode控制器
    /// </summary>
    /// zouql 2016-07-05
    public class DictionaryCodeController : ApiController
    {


        /// <summary>
        /// 
        /// 实例化字典代码逻辑方法类（BLL.sys）
        /// </summary>
        /// zouql      16.07.11 
        private readonly static BLL.BankCredit.DictionaryCode dictionaryCode = new BLL.BankCredit.DictionaryCode();
        /// <summary>
        /// 实例化字典类型逻辑方法类
        /// </summary>
        private readonly static BLL.BankCredit.DictionaryType dictionaryType = new BLL.BankCredit.DictionaryType();
        /// <summary>
        /// 获取字典代码列表
        /// </summary>
        /// zouql 2016-07-05
        /// <returns>字典代码表</returns>
        [HttpGet]
        public Datagrid PageList(int page, int rows)
        {
            Pagination pagination = new Pagination(page, rows);
            NameValueCollection filter = ApiHelper.GetParameters();

            return new Datagrid
            {
                rows = dictionaryCode.PageList(pagination, filter),
                total = pagination.Total
            };
        }
        /// <summary>
        /// 获取字典代码实体
        /// </summary>
        /// zouql 2016-07-05
        /// <param name="code">字典代码</param>
        /// <param name="typeId">字典类型ID</param>
        /// <returns>字典代码实体</returns>
        [HttpGet]
        public object Get(string code, int typeId)
        {
            var c = dictionaryCode.Get(code, typeId);
            var t = dictionaryType.Find(typeId);
            var p = new { c.Code, c.Name, c.ParentCode, DictionaryTypeId = t.DictionaryTypeId, t.ParentType, BDT_ID = t.DictionaryTypeId };
            return p;
        }

        /// <summary>
        /// 添加字典
        /// </summary>
        /// zouql 2016-07-05
        /// <param name="value">字典代码实体</param>
        /// <returns>添加成功与否</returns>
        [HttpPost]
        public IHttpActionResult Create(DictionaryCodeInfo value)
        {
            string messages = string.Empty;
            return dictionaryCode.Create(value, out messages) ? (IHttpActionResult)Ok() : BadRequest(messages);
        }

        //[HttpGet]
        //public IHttpActionResult Create(object value)
        //{
        //    var dic=new DictionaryCodeInfo();
        //    dic = value as DictionaryCodeInfo;
        //    string messages = string.Empty;
        //    return dictionaryCode.Create(dic, out messages) ? (IHttpActionResult)Ok() : BadRequest(messages);
        //}


        /// <summary>
        /// 修改字典
        /// </summary>
        /// zouql 2016-07-05
        /// <param name="value">字典代码实体</param>
        /// <returns>修改结果</returns>
        [HttpPost]
        public IHttpActionResult Modify(DictionaryCodeInfo value)
        {
            return dictionaryCode.Modify(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
        }
        /// <summary>
        /// 下拉框列表
        /// </summary>
        /// zouql    16.07.04
        /// <param name="dictionaryTypeId">字典类型ID</param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetComList()
        {
            List<ComboInfo> cbi = dictionaryCode.GetComList();
            ComboInfo cb = new ComboInfo(string.Empty, string.Empty);
            cbi.Add(cb);
            return cbi;
        }
    }
}
