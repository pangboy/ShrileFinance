using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace DAL.BankCredit
{
    public class ReportMapper : BankAbstractMapper<ReportInfo>
    {
        /// <summary>
        /// 增加一条报文数据
        /// </summary>
        /// cais    16.05.25
        /// <param name="values"></param>
        /// <returns></returns>
        public void Insert(ReportInfo values)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                  INSERT INTO BANK_Reports (MessageTypeID,ReportFileID)  VALUES (@MessageTypeID,@ReportFileID)
                  SELECT SCOPE_IDENTITY()"
              );
            DHelper.AddParameter(comm, "@MessageTypeID", SqlDbType.Int, values.MessageTypeID);
            DHelper.AddParameter(comm, "@ReportFileID", SqlDbType.Int, values.ReportFileID);

            values.ReportID = Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable FindReportData(NameValueCollection data)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT br.*,bst.Describe,brf.CreateTime FROM BANK_Reports  AS br
                    LEFT JOIN BANK_MessageType AS bst ON bst.BMT_ID = br.MessageTypeID
                    LEFT JOIN BANK_ReportFiles AS brf ON brf.FileID = br.ReportFileID
                WHERE ReportFileID = @ReportFileID
            ");
            DHelper.AddInParameter(comm, "@ReportFileID", SqlDbType.Int, data["ReportFileID"]);

            return DHelper.ExecuteDataTable(comm);
        }

        /// <summary>
        /// 获取报文ID
        /// </summary>
        /// yaoy    16.06.31
        /// <param name="reportFileId"></param>
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        public int FindReportId(int reportFileId, int messageTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT ReportID FROM BANK_Reports WHERE MessageTypeID = @MessageTypeID AND ReportFileID = @ReportFileID
            ");
            DHelper.AddInParameter(comm, "@ReportFileID", SqlDbType.Int, reportFileId);
            DHelper.AddInParameter(comm, "@MessageTypeID", SqlDbType.Int, messageTypeId);

            return Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 根据报文ID获取报文集合
        /// </summary>
        /// yaoy    16.09.29
        /// <param name="reportId"></param>
        /// <returns></returns>
        public List<ReportInfo> FindReportList(int reportId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_Reports 
                WHERE ReportFileID = (SELECT ReportFileID FROM BANK_Reports WHERE ReportID = @ReportID )
            ");
            DHelper.AddInParameter(comm, "@ReportID", SqlDbType.Int, reportId);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="value"></param>
        /// <returns></returns>
        public int Modify(ReportInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                UPDATE BANK_Reports SET
                    MessageTypeID = @MessageTypeID,
                    ReportFileID = @ReportFileID
                WHERE ReportID = @ReportId
            ");
            DHelper.AddParameter(comm, "@ReportId", SqlDbType.Int, value.ReportID);
            DHelper.AddParameter(comm, "@MessageTypeID", SqlDbType.Int, value.MessageTypeID);
            DHelper.AddParameter(comm, "@ReportFileID", SqlDbType.Int, value.ReportFileID);

            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));
        }

        /// <summary>
        /// 报文表
        /// </summary>
        /// cais    16.05.25
        /// <param name="reportfileid"></param>
        /// <returns></returns>
        public List<ReportInfo> Find(int reportfileid)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_Reports WHERE ReportFileID = @ReportFileID 
                ORDER BY ReportID
            ");
            DHelper.AddParameter(comm, "@ReportFileID", SqlDbType.Int, reportfileid);
            DataTable dt = DHelper.ExecuteDataTable(comm);
            return LoadAll(dt.Rows);
        }

        /// <summary>
        /// 根据报文id查找报文文件ID
        /// </summary>
        /// yand    16.09.27
        /// <param name="ReportId">报文ID</param>
        /// <returns></returns>
        public ReportInfo FindByReportID(int ReportId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_Reports WHERE ReportID = @ReportId 
                ORDER BY ReportID
            ");
            DHelper.AddParameter(comm, "@ReportId", SqlDbType.Int, ReportId);

            return Load(DHelper.ExecuteDataTable(comm));
        }
    }
}