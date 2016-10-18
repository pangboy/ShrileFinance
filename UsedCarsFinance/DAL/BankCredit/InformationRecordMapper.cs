using DataHelper;
using Model;
using Model.BankCredit;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BankCredit
{
    public class InformationRecordMapper : BankAbstractMapper<InformationRecordInfo>
    {
        /// <summary>
        /// 增加一条信息记录
        /// </summary>
        /// cais    16.05.25
        /// <param name="values">信息记录实体</param>
        /// <returns></returns>
        public void Insert(InformationRecordInfo values)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                INSERT INTO BANK_InformationRecord (Context,addtime,InfoTypeID,ReportID)
                    VALUES (@Context,getdate(),@InfoTypeID,@ReportID)
                SELECT SCOPE_IDENTITY()"
            );

            DHelper.AddParameter(comm, "@Context", SqlDbType.Text, values.Context);
            DHelper.AddParameter(comm, "@InfoTypeID", SqlDbType.NVarChar, values.InfoTypeID);
            DHelper.AddParameter(comm, "@ReportID", SqlDbType.Int, values.ReportID);

            values.RecordID = Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// cais    16.05.25
        /// <param name="value">信息记录实体</param>
        /// <returns></returns>
        public int Update(InformationRecordInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                  UPDATE BANK_InformationRecord SET  
                        Context=@Context,
                        InfoTypeID=@InfoTypeID,
                        ReportID=@ReportID 
                  WHERE RecordID=@RecordID
            ");
            DHelper.AddInParameter(comm, "@RecordID", SqlDbType.Int, value.RecordID);
            DHelper.AddInParameter(comm, "@Context", SqlDbType.Text, value.Context);
            DHelper.AddInParameter(comm, "@InfoTypeID", SqlDbType.NVarChar, value.InfoTypeID);
            DHelper.AddInParameter(comm, "@ReportID", SqlDbType.Int, value.ReportID);

            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));
        }


        /// <summary>
        /// 删除信息记录表
        /// </summary>
        /// cais    16.05.26
        /// <param name="recordID">信息记录表主键</param>
        /// <returns></returns>
        public int DeleteByRecordId(int recordID)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                    DELETE BANK_InformationRecord WHERE RecordID=@RecordID
                ");

            DHelper.AddInParameter(comm, "@RecordID", SqlDbType.Int, recordID);

            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));
        }

        /// <summary>
        /// 查询文件信息
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="reportFilesId"></param>
        /// <returns></returns>
        public InformationRecordInfo Find(int recordId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_InformationRecord WHERE RecordID = @RecordID
            ");
            DHelper.AddInParameter(comm, "@RecordID", SqlDbType.Int, recordId);

            return Load(DHelper.ExecuteDataTable(comm));
        }

        /// <summary>
        /// 列表 
        /// </summary>
        /// cais    16.05.25
        /// <param name="reportFileID">报文文件ID</param>
        /// <returns></returns>
        public DataTable FindInformationRecord(int reportFileID)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT bir.*,bmt.Describe,bit.InfoName,br.* FROM BANK_InformationRecord AS bir
                    LEFT JOIN BANK_InfoType AS bit ON bit.BIT_ID = bir.InfoTypeID
	                LEFT JOIN BANK_MessageType AS bmt ON bmt.BMT_ID = bit.BMT_ID
					LEFT JOIN BANK_Reports as br ON br.ReportID = bir.ReportID
                WHERE bir.ReportID IN (
                    SELECT ReportID FROM BANK_Reports AS br WHERE ReportFileID = @ReportFileID 
                GROUP BY  ReportID )
                ORDER BY InfoTypeID
            ");
            DHelper.AddInParameter(comm, "@ReportFileID", SqlDbType.Int, reportFileID);

            return DHelper.ExecuteDataTable(comm);
        }

        /// <summary>
        /// 通过信息类型ID 获取列表
        /// </summary>
        /// yaoy    16.05.30
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public List<InformationRecordInfo> FindByInfoTypeId(int infoTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_InformationRecord WHERE InfoTypeID = @InfoTypeId
            ");

            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? LoadAll(dt.Rows) : null;
        }

        /// <summary>
        /// 根据记录ID获取信息记录集合
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="reportId"></param>
        /// <returns></returns>
        public List<InformationRecordInfo> FindByReportId(int reportId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_InformationRecord WHERE ReportId = @ReportId
            ");

            DHelper.AddInParameter(comm, "@ReportId", SqlDbType.Int, reportId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? LoadAll(dt.Rows) : null;
        }

        /// <summary>
        /// 通过信息类型ID信息记录类型ID获取列表
        /// </summary>
        /// yaoy    16.06.03
        /// <param name="infoTypeId"></param>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public List<InformationRecordInfo> FindInformationListByInfoTypeIdAndReportId(int infoTypeId, int reportId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_InformationRecord WHERE InfoTypeID = @InfoTypeId AND ReportID = @ReportId
            ");

            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);
            DHelper.AddInParameter(comm, "@ReportId", SqlDbType.Int, reportId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? LoadAll(dt.Rows) : null;
        }

        /// <summary>
        /// 根据信息记录ID查询对应保存的信息记录
        /// </summary>
        /// yand    16.09.27
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public List<InformationRecordInfo> FindInformationListByInfoTypeId(int infoTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_InformationRecord WHERE InfoTypeID = @InfoTypeId
            ");

            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);
            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? LoadAll(dt.Rows) : null;
        }

        /// <summary>
        /// 通过信息类型ID和报文文件ID获取列表
        /// </summary>
        /// cais    16.06.06
        /// <param name="infoTypeId">信息记录类型</param>
        /// <param name="fileId">报文文件ID</param>
        /// <returns></returns>
        public List<InformationRecordInfo> FindInformationListByInfoTypeIdAndFileId(int infoTypeId, int fileId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_InformationRecord WHERE InfoTypeID = @InfoTypeId AND ReportID 
                IN(
                    SELECT br.ReportID FROM BANK_ReportFiles AS brf 
                        LEFT JOIN BANK_Reports AS br ON br.ReportFileID = brf.FileID
                    WHERE brf.FileID = @FileId 
                ) ORDER BY InfoTypeID");

            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);
            DHelper.AddInParameter(comm, "@FileId", SqlDbType.Int, fileId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? LoadAll(dt.Rows) : null;
        }
      
    }
}