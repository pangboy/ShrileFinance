
namespace Web.Controllers.Customer
{
    using Application;
    using Application.ViewModels.OrganizationViewModels;
    using System;
    using System.Web.Http;
    using X.PagedList;

    public class CustomerController : ApiController
    {
        private readonly OrganizationAppService customerAppService;

        public CustomerController(OrganizationAppService service)
        {
            this.customerAppService = service;
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// yand    16.10.25
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Add(OrganizationViewModel value)
        {
            //if (!ModelState.IsValid)
            //{
            //     return BadRequest(ValidModel.ShowErrorFirst(ModelState));
            //}


            customerAppService.Create(value);

            return Ok();

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yand    16.10.25
        /// <param name="value"></param>
        /// <returns></returns>
        public IHttpActionResult Modify(OrganizationViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            customerAppService.Modify(value);

            return Ok();
        }

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// yand    16.10.30
        /// <param name="id">id</param>
        /// <returns></returns>
        public OrganizationViewModel Get(Guid id)
        {
            return customerAppService.Get(id);
        }

        /// <summary>
        /// 查询带分页
        /// </summary>
        /// yand    16.10.30
        /// <param name="Search">筛选条件</param>
        /// <param name="page">页数</param>
        /// <param name="rows">每页显示行数</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetPageList(string Search, int page ,int rows)
        {
            var list = customerAppService.GetPageList(Search, page, rows);

            return Ok(list);
        }
    }
}
