using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model.Finance;

namespace DAL.Finance
{
    public class BankInfoMapper : AbstractMapper<BankInfo>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// zouql   16.07.27
        /// <param name="bankInfo">账户</param>
        /// <returns>执行结果</returns>
        public void Insert(BankInfo bankInfo)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO FANC_BankInfo(FinanceId,BankCard,CreditId,ApplicantId,BankName)
                    VALUES (@FinanceId,@BankCard,@CreditId,@ApplicantId,@BankName)
                SELECT SCOPE_IDENTITY()
            ");
            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, bankInfo.FinanceId);
            DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, bankInfo.CreditId);
            DHelper.AddParameter(comm, "@ApplicantId", SqlDbType.Int, bankInfo.ApplicantId);
            DHelper.AddParameter(comm, "@BankCard", SqlDbType.NVarChar, bankInfo.BankCard);
            DHelper.AddParameter(comm, "@BankName", SqlDbType.NVarChar, bankInfo.BankName);

            bankInfo.BankId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// zouql   16.07.27
        /// <param name="financeId">融资标识</param>
        /// <returns>查询结果</returns>
        public List<BankInfo> List(int financeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
			    SELECT * FROM FANC_BankInfo WHERE FinanceId=@FinanceId
			");
            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, financeId);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }
    }
}
