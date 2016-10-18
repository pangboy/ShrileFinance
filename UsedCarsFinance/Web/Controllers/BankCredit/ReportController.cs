using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using Model.BankCredit;

namespace Web.Controllers.BankCredit
{
    public class ReportController : ApiController
    {
        private static readonly BLL.BankCredit.Report _report = new BLL.BankCredit.Report();

        /// <summary>
        /// 列表
        /// </summary>
        /// yaoy    16.05.26
        /// <returns></returns>
        [HttpGet]
        public DataTable GetReportData()
        {
            NameValueCollection data = ApiHelper.GetParameters();

            return _report.GetReportData(data);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="reportId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult Delete(int recordID)
        {
            return new BLL.BankCredit.InformationRecord().DeleteByrecordID(recordID) ? (IHttpActionResult)Ok() : BadRequest("删除失败");
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Modify(ReportInfo value)
        {
            return _report.Modify(value) ? (IHttpActionResult)Ok() : BadRequest("修改失败");
        }

        /// <summary>
        /// 获取报文ID
        /// </summary>
        /// yaoy    16.06.01
        /// <param name="reportFileId"></param>
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        public int GetReportId(int reportFileId, int messageTypeId)
        {
            return _report.GetReportId(reportFileId, messageTypeId);
        }
    }
}