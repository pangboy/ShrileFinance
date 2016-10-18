using Model.BankCredit;
using System.Collections.Generic;
using System.Data;
using System;
using System.Collections.Specialized;
using System.Transactions;

namespace BLL.BankCredit
{
    public class Report
    {
        private readonly static DAL.BankCredit.ReportMapper reportMapper = new DAL.BankCredit.ReportMapper();
        private readonly static DAL.BankCredit.ReportFilesMapper reportfileMapper = new DAL.BankCredit.ReportFilesMapper();
      
        /// <summary>
        /// 增加一条报文数据
        /// </summary>
        /// cais    16.05.25
        /// <param name="values"></param>
        /// <returns></returns>
        public bool Add(ReportInfo values)
        {
            reportMapper.Insert(values);

            return values.ReportID > 0;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetReportData(NameValueCollection data)
        {
            return reportMapper.FindReportData(data);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Modify(ReportInfo value)
        {
            return reportMapper.Modify(value) > 0;
        }

        /// <summary>
        /// 获取报文ID
        /// </summary>
        /// yaoy    16.05.31
        /// <param name="reportFileId"></param>
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        public int GetReportId(int reportFileId, int messageTypeId)
        {
            return reportMapper.FindReportId(reportFileId, messageTypeId);
        }

        /// <summary>
        /// 根据报文文件ID获取报文集合
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="reportFileId"></param>
        /// <returns></returns>
        public List<ReportInfo> List(int reportFileId)
        {
            return reportMapper.Find(reportFileId);
        }

        /// <summary>
        /// 根据报文ID获取报文集合
        /// </summary>
        /// yaoy    16.09.29
        /// <param name="reportId"></param>
        /// <returns></returns>
        public List<ReportInfo> GetReportList(int reportId)
        {
            return reportMapper.FindReportList(reportId);
        }
    }
}