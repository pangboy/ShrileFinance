using System;
using System.Data;
using System.Data.SqlClient;
using Model.Finance;

namespace DAL.Finance
{
    public class ReviewMapper : AbstractMapper<ReviewInfo>
    {
        /// <summary>
        /// 根据融资ID查询审核报告
        /// </summary>
        /// yangj    16.08.30
        /// <param name="financeId">融资ID</param>
        /// <returns></returns>
        public ReviewInfo Find(int financeId)
        {
            string findStatement =
                "SELECT * FROM FANC_ReviewInfo WHERE financeId = @ID";

            return AbstractFind(findStatement, financeId);
        }

        /// <summary>
        /// 插入初审信息
        /// </summary>
        /// yangj    16.08.30
        /// <param name="value">审核实体</param>
        /// <returns></returns>
        public int Insert(ReviewInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO FANC_ReviewInfo (
                        FinanceId,
                        RepaymentDate,
                        FinanceCost,
                        FinalCost,
                        Payment,
                        AdvicefinanceMoney,
                        ApprovalPrincipal,
                        ApprovalFinanceRatio,
                        ReviewType )
				VALUES (
                        @FinanceId,
                        @RepaymentDate,
                        @FinanceCost,
                        @FinalCost,
                        @Payment,
                        @AdvicefinanceMoney,
                        @ApprovalPrincipal,
                        @ApprovalFinanceRatio,
                        @ReviewType ) 
			");
            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, value.FinanceId);
            DHelper.AddParameter(comm, "@AdvicefinanceMoney", SqlDbType.Decimal, value.AdvicefinanceMoney);
            DHelper.AddParameter(comm, "@ApprovalPrincipal", SqlDbType.Decimal, value.ApprovalPrincipal);
            DHelper.AddParameter(comm, "@ApprovalFinanceRatio", SqlDbType.Float, value.ApprovalFinanceRatio);
            DHelper.AddParameter(comm, "@FinanceCost", SqlDbType.Decimal, value.FinanceCost);
            DHelper.AddParameter(comm, "@FinalCost", SqlDbType.Decimal, value.FinalCost);
            DHelper.AddParameter(comm, "@Payment", SqlDbType.Decimal, value.Payment);
            DHelper.AddParameter(comm, "@RepaymentDate", SqlDbType.Int, value.RepaymentDate);
            DHelper.AddParameter(comm, "@ReviewType", SqlDbType.TinyInt, value.ReviewType);

            return DHelper.ExecuteNonQuery(comm);
        }

        /// <summary>
        /// 根据ID更新审核信息
        /// </summary>
        /// yangj    16.08.30
        /// <param name="value">审核实体</param>
        /// <returns></returns>
        public int Update(ReviewInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                UPDATE FANC_ReviewInfo SET
                        RepaymentDate = @RepaymentDate,
                        FinanceCost = @FinanceCost,
                        FinalCost = @FinalCost,
                        Payment = @Payment,
                        AdvicefinanceMoney = @AdvicefinanceMoney,
                        ApprovalPrincipal = @ApprovalPrincipal,
                        ApprovalFinanceRatio = @ApprovalFinanceRatio,
                        ReviewType = @ReviewType
                WHERE FinanceId = @FinanceId");

            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, value.FinanceId);
            DHelper.AddParameter(comm, "@AdvicefinanceMoney", SqlDbType.Decimal, value.AdvicefinanceMoney);
            DHelper.AddParameter(comm, "@ApprovalPrincipal", SqlDbType.Decimal, value.ApprovalPrincipal);
            DHelper.AddParameter(comm, "@ApprovalFinanceRatio", SqlDbType.Float, value.ApprovalFinanceRatio);
            DHelper.AddParameter(comm, "@FinanceCost", SqlDbType.Decimal, value.FinanceCost);
            DHelper.AddParameter(comm, "@FinalCost", SqlDbType.Decimal, value.FinalCost);
            DHelper.AddParameter(comm, "@Payment", SqlDbType.Decimal, value.Payment);
            DHelper.AddParameter(comm, "@RepaymentDate", SqlDbType.Int, value.RepaymentDate);
            DHelper.AddParameter(comm, "@ReviewType", SqlDbType.TinyInt, value.ReviewType);

            return DHelper.ExecuteNonQuery(comm);
        }
    }
}
