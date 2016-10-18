using Model.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.Finance
{
    public class CreditExamineReportController : ApiController
    {
        private static readonly BLL.Finance.CreditExamineReport _CreditExamineReport = new BLL.Finance.CreditExamineReport();

        /// <summary>
        /// 根据融资Id获取信审报告信息
        /// </summary>
        /// yand    16.04.26
        /// <param name="financeId">融资ID</param>
        /// <returns></returns>
        [HttpGet]
        public List<ApplicantInfo> GetByFinanceId(int financeId)
        {
            return new BLL.Finance.Applicant().List(financeId);
        }

        /// <summary>
        /// 根据ID获取征信信息
        /// </summary>
        /// yand    16.04.26
        /// <param name="financeId"></param>
        /// <returns></returns>
        [HttpGet]
        public CreditExamineReportInfo Get(int financeId)
        {
            return _CreditExamineReport.Get(financeId);
        }

        /// <summary>
        /// 插入信息
        /// </summary>
        /// yand    16.04.26
        /// <param name="value"></param>
        /// <returns></returns>
       [HttpPost]
        public bool Post(CreditExamineReportInfo value)
        {
            return _CreditExamineReport.Add(value);
        }

        /// <summary>
        /// 根据ID更新信审信息
        /// </summary>
        /// yand    16.04.27
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
       public bool Put(CreditExamineReportInfo value)
       {
           return _CreditExamineReport.Modify(value);
       }
    }
}
