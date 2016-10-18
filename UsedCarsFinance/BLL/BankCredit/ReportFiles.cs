using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Collections.Specialized;
using System.Data;
using Model.BankCredit;
using System.Transactions;
using System.Web;

namespace BLL.BankCredit
{
    public class ReportFiles
    {
        private readonly static DAL.BankCredit.ReportFilesMapper reportFilesMapper = new DAL.BankCredit.ReportFilesMapper();
        private readonly static DAL.BankCredit.MessageTypeMapper messageTypeMapper = new DAL.BankCredit.MessageTypeMapper();
        private readonly static DAL.BankCredit.ReportMapper reportMapper = new DAL.BankCredit.ReportMapper();

        /// <summary>
        /// 添加
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="value"></param>
        /// <returns></returns>
        public int Add(NameValueCollection data)
        {
            bool result = true;
            int reportFilesId = 0;
            ReportFilesInfo value = new ReportFilesInfo();

            value.MessageFileId = Convert.ToInt32(data["messageFileId"].ToString());
            value.ServiceObj = Convert.ToInt32(data["serviceObj"].ToString());
            value.ReportState = 3;//编辑状态
            value.CreateTime = DateTime.Now;
            value.Operator = new BLL.User.User().CurrentUser().Name;
            //获取报文类型列表
            List<MessageTypeInfo> list = messageTypeMapper.List(value.MessageFileId);
            ReportInfo report = new ReportInfo();

            using (TransactionScope scope = new TransactionScope())
            {
                reportFilesId = reportFilesMapper.Insert(value);
                result = reportFilesId > 0;

                report.ReportFileID = reportFilesId;
                foreach (var item in list)
                {
                    report.MessageTypeID = item.MessageTypeId;

                    reportMapper.Insert(report);
                    result = report.ReportID > 0;
                }

                if (result)
                {
                    scope.Complete();
                }
            }

            return reportFilesId;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Modify(ReportFilesInfo value)
        {
            return reportFilesMapper.Update(value) > 0;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="page"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetReportFilesData(Pagination page, NameValueCollection data)
        {
            return reportFilesMapper.FindReportFilesData(page, data);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="reportFilesId"></param>
        /// <returns></returns>
        public ReportFilesInfo Get(int reportFilesId)
        {
            return reportFilesMapper.Find(reportFilesId);
        }
        /// <summary>
        /// 根据当前操作者进行查询
        /// </summary>
        /// yand    16.06.14
        /// <param name="reportFilesId"></param>
        /// <returns></returns>
        public ReportFilesInfo GetByOperator(int reportFilesId)
        {
            string Operator = new BLL.User.User().CurrentUser().Name;
            return reportFilesMapper.FindByOperator(reportFilesId, Operator);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="reportFilesId"></param>
        /// <returns></returns>
        public bool Delete(int reportFilesId)
        {
            try
            {
                List < ReportInfo > reportInfo = new DAL.BankCredit.ReportMapper().Find(reportFilesId);
                if (reportInfo.Count > 0)
                {
                    foreach (var item in reportInfo)
                    {
                        new DAL.BankCredit.TempRecordMapper().DeleteByReportId(item.ReportID);
                    }
                }
                reportFilesMapper.Delete(reportFilesId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 发送报文文件信息
        /// </summary>
        /// yaoy    16.07.04
        /// <param name="fileId"></param>
        /// <returns></returns>
        public bool SendReportFileInfo(int fileId)
        {
            bool result = false;
            
            ReportFilesInfo reportFileInfo = new ReportFilesInfo();

            // 生成报文文件内容
            string reportFileContent = new DataRule().CombinaReportData(fileId);
            // 获取文件内容
            if (reportFileContent != string.Empty)
            {
                // 获取文件名称
                string reportFileName = new DataUtil().CreateTxtFile(fileId, reportFileContent);

                if (reportFileName != string.Empty)
                {
                    ReportFilesInfo data = new DAL.BankCredit.ReportFilesMapper().Find(fileId);

                    reportFileInfo.FileID = fileId;
                    reportFileInfo.ReportState = 1;
                    reportFileInfo.ServiceObj = data.ServiceObj;
                    reportFileInfo.CreateTime = data.CreateTime;
                    reportFileInfo.SendTime = DateTime.Now;
                    reportFileInfo.MessageFileId = data.MessageFileId;
                    reportFileInfo.ReportTextName = reportFileName;

                    result = reportFilesMapper.Update(reportFileInfo) > 0;
                }
            }

            return result;
        }

        public bool Save(int FileId,string FilesName,string Remarks)
        {
            bool result = false;

            ReportFilesInfo reportFileInfo = new ReportFilesInfo();
            reportFileInfo.FileID = FileId;
            reportFileInfo.FilesName = FilesName;
            reportFileInfo.Remarks = Remarks;
            result = reportFilesMapper.UpdateRemarks(reportFileInfo) > 0;
            return result;

        }
    }
}
