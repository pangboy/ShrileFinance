namespace Web.Controllers.Credit
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using Application;
    using Application.ViewModels;
    using Application.ViewModels.PartnerViewModels;
    using Models;

    public class CreditController : ApiController
    {
        private static readonly BLL.Credit.Partner _partner = new BLL.Credit.Partner();
        private static readonly BLL.Credit.Credit credit = new BLL.Credit.Credit();
        private readonly PartnerAppService service;

        public CreditController(PartnerAppService service)
        {
            this.service = service;
        }

        /// <summary>
        /// 获取渠道主体信息
        /// </summary>
        /// <param name="creditId">授信标识</param>
        /// qiy     16.03.29
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(Guid creditId)
        {
            var partner = service.Get(creditId);

            return partner != null ? (IHttpActionResult)Ok(partner) : NotFound();
        }

        /// <summary>
        /// 获取授信主体选项
        /// </summary>
        /// qiy     16.03.29
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> Option()
        {
            return _partner.Option();
        }

        /// <summary>
        /// 渠道列表
        /// </summary>
        /// qiy     16.03.29
        /// <param name="page">页码</param>
        /// <param name="rows">尺寸</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAll(int page, int rows, string searchString = null)
        {
            var list = service.List(searchString, page, rows);

            return Ok(new PagedListViewModel<PartnerViewModel>(list));
        }

        /// <summary>
        /// 添加渠道主体
        /// </summary>
        /// qiy     16.03.29
        /// <param name="model">值</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post(PartnerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.Create(model);

            return Ok();
        }

        /// <summary>
        /// 修改渠道主体
        /// </summary>
        /// qiy     16.03.29
        /// <param name="model">值</param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Put(PartnerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.Modify(model);

            return Ok();
        }
    }
}