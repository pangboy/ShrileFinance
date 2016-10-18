using Model;
using Model.Credit;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Http;

namespace Web.Controllers.Credit
{
    public class CreditController : ApiController
    {
        private readonly static BLL.Credit.Partner _partner = new BLL.Credit.Partner();

        /// <summary>
        /// 获取渠道主体信息
        /// </summary>
        /// <param name="creditId">授信标识</param>
        /// qiy		16.03.29
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(int creditId)
        {
            PartnerInfo partner = _partner.Get(creditId);

            return partner != null ? (IHttpActionResult)Ok(partner) : NotFound();
        }

        /// <summary>
        /// 获取授信主体选项
        /// </summary>
        /// qiy		16.03.29
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> Option()
        {
            return _partner.Option();
        }

        /// <summary>
        /// 渠道列表
        /// </summary>
        /// qiy		16.03.29
        /// <param name="page">页码</param>
        /// <param name="rows">尺寸</param>
        /// <returns></returns>
        [HttpGet]
        public Datagrid GetAll(int page, int rows)
        {
            Pagination pagination = new Pagination(page, rows);
            NameValueCollection filter = ApiHelper.GetParameters();

            return new Datagrid
            {
                rows = _partner.List(pagination, filter),
                total = pagination.Total
            };
        }

        /// <summary>
        /// 添加渠道主体
        /// </summary>
        /// qiy		16.03.29
        /// <param name="value">值</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post(PartnerInfo value)
        {
            return _partner.Add(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
        }

        /// <summary>
        /// 修改渠道主体
        /// </summary>
        /// qiy		16.03.29
        /// <param name="value">值</param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Put(PartnerInfo value)
        {
            return _partner.Modify(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
        }

        private readonly static BLL.Credit.Credit credit = new BLL.Credit.Credit();

        /// <summary>
        /// 查询所有的省，用于页面
        /// </summary>
        /// cais    16.05.09
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> OptionProvince()
        {
            return credit.OptionProvince();
        }

        /// <summary>
        /// 通过省查询市，用于页面  列表(Combo)
        /// </summary>
        /// cais    16.05.09
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> OptionCitys(int ProvinceCode)
        {
            return credit.OptionCitys(ProvinceCode);
        }

        /// <summary>
        /// 通过市区代码查询市，用于页面列表(Combo)
        /// </summary>
        /// cais    16.05.09
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> OptionCity(int CityCode)
        {
            return credit.OptionCity(CityCode);
        }
    }
}