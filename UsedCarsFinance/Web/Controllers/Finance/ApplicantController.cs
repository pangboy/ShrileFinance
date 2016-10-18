using Model;
using Model.Finance;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace Web.Controllers.Finance
{
    public class ApplicantController : ApiController
    {
        private readonly static BLL.Finance.Applicant _finance = new BLL.Finance.Applicant();

      
        /// <summary>
        /// 通过ApplicantId查询单个附加申请人下的信息
        /// </summary>
        /// cais    16.03.31
        /// <param name="applicantId"></param>
        /// <returns></returns>
        public ApplicantInfo Get(int applicantId)
        {
            return _finance.Get(applicantId);
        }

        /// <summary>
        /// 通过实体，增加一个申请人信息
        /// </summary>
        /// cais    16.03.31
        /// <param name="applicantInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public bool POST([FromBody]ApplicantInfo applicantInfo)
        {
            return _finance.Add(applicantInfo);
        }

        /// <summary>
        /// 通过实体类修改
        /// </summary>
        /// <param name="applicantInfo"></param>
        /// cais    16.04.07
        /// <returns></returns>
        [HttpPut]
        public bool Put(ApplicantInfo applicantInfo)
        {
            return _finance.Modify(applicantInfo);
        }

        /// <summary>
        /// 删除附加申请人信息
        /// </summary>
        /// cais    16.03.31
        /// <param name="applicantId"></param>
        /// <returns></returns>
        [HttpGet]
        public bool Delete(int applicantId)
        {
            return _finance.Delete(applicantId);
        }
        /// <summary>
        /// 获取申请人姓名和ID
        /// zouql   16.07.27
        /// yangj   16.09.14(还款用户直接默认为主要申请人名字，不用下拉菜单)
        /// </summary>
        /// <returns>集合</returns>
        [HttpGet]
        public ApplicantInfo Option(int financeId)
        {
            return _finance.Option(financeId);
        }
    }
}