using Models;
using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.BankCredit
{
    public abstract class BaseTest
    {
        protected BaseTest()
        {
            var i1 = Test();
            var i2 = this.Test();
        }

        public virtual int Test()
        {
            return 1;
        }
    }
    public class SubTest : BaseTest
    {
        public SubTest() : base()
        {
        }

        public override int Test()
        {
            base.Test();
            return 2;

        }
    }

    public class MetaController : ApiController
    {
        private readonly static BLL.BankCredit.Meta meta = new BLL.BankCredit.Meta();

        /// <summary>
        /// 根据数据元标识查找记录
        /// </summary>
        /// yangj    16.07.05
        /// <param name="metaCode">字典类型ID</param>
        /// <returns></returns>
        [HttpGet]
        public MetaInfo GetMeta(int metaCode)
        {
            return meta.Find(metaCode);
        }

        [HttpGet]
        public void Test()
        {
            var sub = new SubTest();
        }

        /// <summary>
        /// 根据报文ID查找记录列表
        /// </summary>
        /// yangj    16.07.05
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        [HttpGet]
        public Datagrid MetaList(int page, int rows)
        {
            Pagination pagination = new Pagination(page, rows);
            NameValueCollection filter = ApiHelper.GetParameters();

            return new Datagrid
            {
                rows = meta.List(pagination, filter),
                total = pagination.Total
            };
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// yangj    16.07.05
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Modify(MetaInfo value)
        {
            return meta.Modify(value) ? (IHttpActionResult)Ok() : BadRequest("修改失败");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// yangj    16.07.05
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Add(MetaInfo value)
        {
            return meta.Add(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
        }

        /// <summary>
        ///  根据数据元标识和服务对象作为复合主键，验证重复性
        /// </summary>
        /// yangj    16.07.05
        /// <param name="metaCode">字典类型ID</param>
        /// <param name="type">服务对象</param>
        /// <returns></returns>
        [HttpGet]
        public bool RepeatCheck(int metaCode, int type)
        {
            MetaInfo metaInfo = meta.FindByPK(metaCode,type);
            if (metaInfo != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 根据数据元标识和服务对象作为复合主键，验证重复性
        /// </summary>
        /// yangj     16.07.07
        /// <param name="metaCode">数据元标识</param>
        /// <param name="type">服务对象</param>
        /// <returns></re
        [HttpGet]
        public MetaInfo FindByPK(int metaCode, int type)
        {
            return meta.FindByPK(metaCode, type);
        }
    }
}
