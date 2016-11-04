using System;
using System.Data;
using System.Data.SqlClient;
using Models.BankCredit;

namespace DAL.BankCredit
{
    public class TempRecordMapper : BankAbstractMapper<TempRecordInfo>
    {
        /// <summary>
        /// 增加一条临时数据记录
        /// </summary>
        /// yangj    16.09.21
        /// <param name="values">临时数据记录实体</param>
        public void Insert(TempRecordInfo values)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                INSERT INTO Bank_TempRecord (Context,BIT_ID,ReportID,UI_ID)
                    VALUES (@Context,@BIT_ID,@ReportID,@UI_ID)
                SELECT SCOPE_IDENTITY()"
            );

            DHelper.AddParameter(comm, "@Context", SqlDbType.Text, values.Context);
            DHelper.AddParameter(comm, "@BIT_ID", SqlDbType.NVarChar, values.InfoTypeId);
            DHelper.AddParameter(comm, "@ReportID", SqlDbType.Int, values.ReportId);
            DHelper.AddParameter(comm, "@UI_ID", SqlDbType.NVarChar, values.UserId);

            values.TempInfoId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// yangj    16.09.21
        /// <param name="value">临时数据记录实体</param>
        /// <returns></returns>
        public int Update(TempRecordInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                  UPDATE Bank_TempRecord SET  
                        Context=@Context,
                        BIT_ID=@BIT_ID,
                        ReportID=@ReportID,
                        UI_ID=@UI_ID 
                  WHERE BTI_ID=@TempInfoID
            ");
            DHelper.AddInParameter(comm, "@TempInfoID", SqlDbType.Int, value.TempInfoId);
            DHelper.AddInParameter(comm, "@Context", SqlDbType.Text, value.Context);
            DHelper.AddInParameter(comm, "@BIT_ID", SqlDbType.NVarChar, value.InfoTypeId);
            DHelper.AddInParameter(comm, "@ReportID", SqlDbType.Int, value.ReportId);
            DHelper.AddInParameter(comm, "@UI_ID", SqlDbType.NVarChar, value.UserId);

            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));
        }

        /// <summary>
        /// 删除一条临时数据
        /// </summary>
        /// yangj    16.09.21
        /// <param name="infoTypeId">信息揭露类型标识</param>
        /// <param name="reportId">报文标识</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public int Delete(int infoTypeId, int reportId, string userId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                    DELETE Bank_TempRecord WHERE BIT_ID = @BIT_ID AND ReportID = @ReportID AND UI_ID = @UI_ID
                ");

            DHelper.AddInParameter(comm, "@BIT_ID", SqlDbType.Int, infoTypeId);
            DHelper.AddInParameter(comm, "@ReportID", SqlDbType.Int, reportId);
            DHelper.AddInParameter(comm, "@UI_ID", SqlDbType.NVarChar, userId);

            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));
        }
        /// <summary>
        /// 删除根据reportId
        /// </summary>
        /// yand    16.10.14
        /// <param name="reportId"></param>
        /// <returns></returns>
        public int DeleteByReportId(int reportId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                    DELETE Bank_TempRecord WHERE ReportID = @ReportID 
                ");

            DHelper.AddInParameter(comm, "@ReportID", SqlDbType.Int, reportId);
            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));
        }

        /// <summary>
        /// 查询临时报文
        /// </summary>
        /// yangj    16.09.21
        /// <param name="infoTypeId">信息揭露类型标识</param>
        /// <param name="reportId">报文标识</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public TempRecordInfo Find(int infoTypeId, int reportId, string userId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM Bank_TempRecord WHERE BIT_ID = @BIT_ID AND ReportID = @ReportID AND UI_ID = @UI_ID
            ");
            DHelper.AddInParameter(comm, "@BIT_ID", SqlDbType.Int, infoTypeId);
            DHelper.AddInParameter(comm, "@ReportID", SqlDbType.Int, reportId);
            DHelper.AddInParameter(comm, "@UI_ID", SqlDbType.NVarChar, userId);

            return Load(DHelper.ExecuteDataTable(comm));
        }
    }
}
