using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;
using System.Collections.Specialized;
using Model.BankCredit;

namespace DAL.BankCredit
{
    public class ReportFilesMapper : BankAbstractMapper<ReportFilesInfo>
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="value"></param>
        /// <returns></returns>
        public int Insert(ReportFilesInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                INSERT INTO BANK_ReportFiles(ReportState,CreateTime,ServiceObj,ReportTextName,MessageFileID,Operator)
                    VALUES(@ReportState,@CreateTime,@ServiceObj,@ReportTextName,@MessageFileId,@Operator)
                SELECT SCOPE_IDENTITY()
            ");
            DHelper.AddInParameter(comm, "@ReportState", SqlDbType.Int, value.ReportState);
            DHelper.AddInParameter(comm, "@CreateTime", SqlDbType.DateTime, value.CreateTime);
            DHelper.AddInParameter(comm, "@ServiceObj", SqlDbType.Int, value.ServiceObj);
            DHelper.AddInParameter(comm, "@ReportTextName", SqlDbType.NVarChar, value.ReportTextName);
            DHelper.AddInParameter(comm, "@MessageFileId", SqlDbType.Int, value.MessageFileId);
            DHelper.AddInParameter(comm, "@Operator", SqlDbType.NVarChar, value.Operator);
            return Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="value"></param>
        /// <returns></returns>
        public int Update(ReportFilesInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                UPDATE BANK_ReportFiles SET
                    MessageFileID = @MessageFileId,
                    ReportState = @ReportState ,
                    CreateTime = @CreateTime ,
                    SendTime = @SendTime ,
                    ServiceObj = @ServiceObj ,
                    ReportTextName = @ReportTextName
                WHERE FileID = @FileId
            ");
            DHelper.AddInParameter(comm, "@FileId", SqlDbType.Int, value.FileID);
            DHelper.AddInParameter(comm, "@MessageFileId", SqlDbType.Int, value.MessageFileId);
            DHelper.AddInParameter(comm, "@ReportState", SqlDbType.Int, value.ReportState);
            DHelper.AddInParameter(comm, "@CreateTime", SqlDbType.DateTime, value.CreateTime);
            DHelper.AddInParameter(comm, "@SendTime", SqlDbType.DateTime, value.SendTime);
            DHelper.AddInParameter(comm, "@ServiceObj", SqlDbType.Int, value.ServiceObj);
            DHelper.AddInParameter(comm, "@ReportTextName", SqlDbType.NVarChar, value.ReportTextName);
          
            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int UpdateRemarks(ReportFilesInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                UPDATE BANK_ReportFiles SET
                    FilesName = @FilesName,
                    Remarks = @Remarks
                WHERE FileID = @FileId
            ");
            DHelper.AddInParameter(comm, "@FileId", SqlDbType.Int, value.FileID);
            DHelper.AddInParameter(comm, "@Remarks", SqlDbType.NVarChar, value.Remarks);
            DHelper.AddInParameter(comm, "@FilesName", SqlDbType.NVarChar, value.FilesName);
            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// yand    16.06.14
        /// <param name="value"></param>
        /// <returns></returns>
        public int UpdateState(ReportFilesInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                UPDATE BANK_ReportFiles SET
                    ReportState = @ReportState 
                WHERE FileID = @FileId
            ");
            DHelper.AddInParameter(comm, "@FileId", SqlDbType.Int, value.FileID);
            DHelper.AddInParameter(comm, "@ReportState", SqlDbType.Int, value.ReportState);

            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));
        }

        /// <summary>
        /// 删除文件信息
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="reportFilesId"></param>
        /// <returns></returns>
        public int Delete(int reportFilesId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                DELETE FROM BANK_ReportFiles WHERE FileID = @FileID
            ");
            DHelper.AddInParameter(comm, "@FileID", SqlDbType.Int, reportFilesId);
            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));

        }

        /// <summary>
        /// 查询文件信息
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="reportFilesId"></param>
        /// <returns></returns>
        public ReportFilesInfo Find(int reportFilesId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_ReportFiles WHERE FileID = @FileID
            ");
            DHelper.AddInParameter(comm, "@FileID", SqlDbType.Int, reportFilesId);

            return Load(DHelper.ExecuteDataTable(comm));
        }
        /// <summary>
        /// 根据操作者查询
        /// </summary>
        /// yand    16.06.14
        /// <param name="reportFilesId"></param>
        /// <returns></returns>
        public ReportFilesInfo FindByOperator(int reportFilesId, string Operator)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_ReportFiles WHERE FileID = @FileID AND Operator = @Operator
            ");
            DHelper.AddInParameter(comm, "@FileID", SqlDbType.Int, reportFilesId);
            DHelper.AddInParameter(comm, "@Operator", SqlDbType.NVarChar, Operator);
            return Load(DHelper.ExecuteDataTable(comm));
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// yaoy    16.05.25
        /// yangj   16.09.21    新增时间、文件名筛选
        /// <returns></returns>
        public DataTable FindReportFilesData(Pagination page, NameValueCollection data)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT rownum,brf.FileID, brf.CreateTime,brf.SendTime,brf.ReportTextName,
                    CASE brf.ReportState WHEN 1 THEN '已发送' WHEN 2 THEN '已编辑' WHEN 3 THEN '已创建' WHEN 4 THEN '接受' END AS ReportState,
                    CASE brf.ServiceObj WHEN 1 THEN '企业' WHEN 2 THEN '个人' END AS ServiceObj,
                    brf.Remarks,brf.Operator,brf.FilesName,
                    bmf.FileName 
                FROM BANK_ReportFiles AS brf
                    RIGHT JOIN( 
                        SELECT TOP(@End) ROW_NUMBER() OVER(ORDER BY FileID DESC) AS rownum,FileID FROM BANK_ReportFiles
                        WHERE (@ServiceObj IS NULL OR ServiceObj = @ServiceObj)
                            AND (@MessageFileID IS NULL OR MessageFileID = @MessageFileID)
                            AND (@FilesName IS NULL OR FilesName LIKE @FilesName +'%')
                            AND (@BeginTime IS NULL OR DATEDIFF(day, CreateTime, @BeginTime) <= 0) 
                            AND (@EndTime IS NULL OR DATEDIFF(day, CreateTime, @EndTime) >= 0) 
                    ) AS temp ON temp.FileID = brf.FileID
                    LEFT JOIN BANK_MessageFile AS bmf ON bmf.BMF_ID = brf.MessageFileID
                 WHERE rownum > @Begin AND (@ServiceObj IS NULL OR ServiceObj = @ServiceObj)
                       AND (@MessageFileID IS NULL OR brf.MessageFileID = @MessageFileID)
                       AND (@FilesName IS NULL OR FilesName LIKE @FilesName +'%')
                       AND (@BeginTime IS NULL OR DATEDIFF(day, CreateTime, @BeginTime) <= 0) 
                       AND (@EndTime IS NULL OR DATEDIFF(day, CreateTime, @EndTime) >= 0) 
            ");

            DHelper.AddParameter(comm, "@Begin", SqlDbType.Int, page.Begin);
            DHelper.AddParameter(comm, "@End", SqlDbType.Int, page.End);

            DHelper.AddParameter(comm, "@MessageFileID", SqlDbType.Int, data["MessageFileID"]);
            DHelper.AddParameter(comm, "@ServiceObj", SqlDbType.Int, data["ServiceObj"]);
            DHelper.AddParameter(comm, "@FilesName", SqlDbType.NVarChar, data["FilesName"]);
            DHelper.AddInParameter(comm, "@BeginTime", SqlDbType.DateTime, data["BeginTime"]);
            DHelper.AddInParameter(comm, "@EndTime", SqlDbType.DateTime, data["EndTime"]);

            SqlCommand commPage = DHelper.GetSqlCommand(@"
                SELECT COUNT(*) FROM BANK_ReportFiles
                WHERE (@ServiceObj IS NULL OR ServiceObj = @ServiceObj) 
                    AND (@MessageFileID IS NULL OR MessageFileID = @MessageFileID) 
                    AND (@FilesName IS NULL OR FilesName LIKE @FilesName +'%')
                    AND (@BeginTime IS NULL OR DATEDIFF(day, CreateTime, @BeginTime) <= 0) 
                    AND (@EndTime IS NULL OR DATEDIFF(day, CreateTime, @EndTime) >= 0) 
            ");
            DHelper.AddParameter(commPage, "@MessageFileID", SqlDbType.Int, data["MessageFileID"]);
            DHelper.AddParameter(commPage, "@ServiceObj", SqlDbType.Int, data["ServiceObj"]);
            DHelper.AddParameter(commPage, "@FilesName", SqlDbType.NVarChar, data["FilesName"]);
            DHelper.AddInParameter(commPage, "@BeginTime", SqlDbType.DateTime, data["BeginTime"]);
            DHelper.AddInParameter(commPage, "@EndTime", SqlDbType.DateTime, data["EndTime"]);

            page.Total = Convert.ToInt32(DHelper.ExecuteScalar(commPage));

            return DHelper.ExecuteDataTable(comm);
        }
 
        /// <summary>
        /// 根据报文ID查询报文文件ID并返回该报文文件下所有的信息记录
        /// </summary>
        /// yand    16.06.16
        /// <param name="ReportID">报文ID</param>
        /// <returns></returns>
       public DataTable FindData(int ReportID)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_ReportFiles AS brf LEFT JOIN 
                     BANK_Reports AS br ON brf.FileID = br.ReportFileID
                     LEFT JOIN BANK_InformationRecord AS bir ON bir.ReportID = br.ReportID
                     where ReportFileID = (select ReportFileID FROM BANK_Reports WHERE ReportID = @ReportID)
            ");

            DHelper.AddParameter(comm, "@ReportID", SqlDbType.Int, ReportID);

            return DHelper.ExecuteDataTable(comm);
        }

        /// <summary>
        /// 获取同种类型文件数量
        /// </summary>
        /// yaoy    16.07.12
        /// <param name="partnerName"></param>
        /// <returns></returns>
        public int FindFileCount(string partnerName)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT COUNT(*) FROM BANK_ReportFiles WHERE ReportTextName LIKE @PartnerName +'%'
            ");
            DHelper.AddInParameter(comm, "@PartnerName", SqlDbType.NVarChar, partnerName);

            return Convert.ToInt32(DHelper.ExecuteScalar(comm));

        }

        /// <summary>
        /// 获取当前的该类型的信息记录
        /// </summary>
        /// yand    16.10.14
        /// <param name="partnerName"></param>
        /// <returns></returns>
        public List<ReportFilesInfo> FindFileByPartnerName(string partnerName)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_ReportFiles WHERE ReportTextName LIKE @PartnerName +'%' ORDER BY ReportTextName DESC
            ");
            DHelper.AddInParameter(comm, "@PartnerName", SqlDbType.NVarChar, partnerName);
            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }
    }
}
