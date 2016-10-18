using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model.Finance;

namespace DAL.Finance
{
    public class BorrowMapper : AbstractMapper<BorrowInfo>
    {
        /// <summary>
        /// 查找指定的借贷信息
        /// </summary>
        /// zouql   16.08.30
        /// <param name="financeId">融资标识</param>
        /// <returns>借贷信息</returns>
        public BorrowInfo Find(int financeId)
        {
            SqlCommand comm = new SqlCommand(@"
                    SELECT 
                        BI_ID,
                        FinanceId,
                        ApprovalPrincipal,
                        InterestRate,
                        FinancingPeriods,
                        RepaymentInterval,
                        RepaymentMethod,
                        RepaymentDate,
                        FinanceAddDate,
                        [State],
                        OncePayMonths,
                        FinalRatio,
                        CustomerBailRatio,
                        FinalCost,
                        ExtralCost
                    FROM 
                        FANC_Borrow
                    WHERE FinanceId=@financeId
        ");

            DHelper.AddParameter(comm, "@financeId", SqlDbType.Int, financeId);

            var dt = DHelper.ExecuteDataTable(comm);

            return Load(dt.Rows[0]);
        }

        /// <summary>
        /// 查找所有借贷信息
        /// </summary>
        /// zouql   16.08.30
        /// <returns>借贷信息List</returns>
        public List<BorrowInfo> FindAll()
        {
            SqlCommand comm = new SqlCommand(@"
                    SELECT 
                        BI_ID,
                        FinanceId,
                        ApprovalPrincipal,
                        InterestRate,
                        FinancingPeriods,
                        RepaymentInterval,
                        RepaymentMethod,
                        RepaymentDate,
                        FinanceAddDate,
                        [State],
                        OncePayMonths,
                        FinalRatio,
                        CustomerBailRatio,
                        FinalCost,
                        ExtralCost
                    FROM FANC_Borrow
                    WHERE FinanceId=@financeId
        ");

            var dt = DHelper.ExecuteDataTable(comm);

            return LoadAll(dt.Rows);
        }

        /// <summary>
        /// 插入指定的借贷信息
        /// </summary>
        /// zouql   16.08.30
        /// <param name="borrowInfo">借贷信息</param>
        /// <returns>操作结果</returns>
        public int Insert(BorrowInfo borrowInfo)
        {
            SqlCommand comm = new SqlCommand(@"
                             INSERT INTO FANC_Borrow
                              ( 
	                               FinanceId,
                                   ApprovalPrincipal,
                                   InterestRate,
                                   FinancingPeriods,
                                   RepaymentInterval,
                                   RepaymentMethod,
                                   RepaymentDate,
                                   FinanceAddDate,
                                   [State],
                                   OncePayMonths,
                                   FinalRatio,
                                   CustomerBailRatio,
                                   FinalCost,
                                   ExtralCost
	                              )
                              VALUES
                              (
                                  @FinanceId,
                                  @ApprovalPrincipal,
                                  @InterestRate,
                                  @FinancingPeriods,
                                  @RepaymentInterval,
                                  @RepaymentMethod,
                                  @RepaymentDate,
                                  @FinanceAddDate,
                                  @State,
                                  @OncePayMonths,
                                  @FinalRatio,
                                  @CustomerBailRatio,
                                  @FinalCost,
                                  @ExtralCost
	                              ) 
                    SELECT SCOPE_IDENTITY()
        ");

            DHelper.AddParameter(comm, "@financeId", SqlDbType.Int, borrowInfo.FinanceId);
            DHelper.AddParameter(comm, "@ApprovalPrincipal", SqlDbType.Decimal, borrowInfo.ApprovalPrincipal);
            DHelper.AddParameter(comm, "@InterestRate", SqlDbType.Float, borrowInfo.InterestRate);
            DHelper.AddParameter(comm, "@FinancingPeriods", SqlDbType.Int, borrowInfo.FinancingPeriods);
            DHelper.AddParameter(comm, "@RepaymentInterval", SqlDbType.Int, borrowInfo.RepaymentInterval);
            DHelper.AddParameter(comm, "@RepaymentMethod", SqlDbType.NVarChar, borrowInfo.RepaymentMethod);
            DHelper.AddParameter(comm, "@RepaymentDate", SqlDbType.Int, borrowInfo.RepaymentDate);
            DHelper.AddParameter(comm, "@FinanceAddDate", SqlDbType.DateTime, borrowInfo.FinanceAddDate);
            DHelper.AddParameter(comm, "@State", SqlDbType.NVarChar, borrowInfo.State);
            DHelper.AddParameter(comm, "@OncePayMonths", SqlDbType.Int, borrowInfo.OncePayMonths);
            DHelper.AddParameter(comm, "@FinalRatio", SqlDbType.Float, borrowInfo.FinalRatio);
            DHelper.AddParameter(comm, "@CustomerBailRatio", SqlDbType.Float, borrowInfo.CustomerBailRatio);
            DHelper.AddParameter(comm, "@FinalCost", SqlDbType.Decimal, borrowInfo.FinalCost);
            DHelper.AddParameter(comm, "@ExtralCost", SqlDbType.Decimal, borrowInfo.ExtralCost);

            return Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 跟新指定的借贷信息
        /// </summary>
        /// zouql   16.08.30
        /// <param name="borrowInfo">借贷信息</param>
        /// <returns>操作结果</returns>
        public int Update(BorrowInfo borrowInfo)
        {
            SqlCommand comm = new SqlCommand(@"
                        UPDATE FANC_Borrow SET
                              ApprovalPrincipal=@ApprovalPrincipal,
                              InterestRate=@InterestRate,
                              FinancingPeriods=@FinancingPeriods,
                              RepaymentInterval=@RepaymentInterval,
                              RepaymentMethod=@RepaymentMethod,
                              RepaymentDate=@RepaymentDate,
                              FinanceAddDate=@FinanceAddDate,
                              [State]=@State,
                              OncePayMonths=@OncePayMonths,
                              FinalRatio=@FinalRatio,
                              CustomerBailRatio=@CustomerBailRatio,
                              FinalCost=@FinalCost,
                              ExtralCost=@ExtralCost
                        WHERE FinanceId=@financeId
        ");

            DHelper.AddParameter(comm, "@financeId", SqlDbType.Int, borrowInfo.FinanceId);
            DHelper.AddParameter(comm, "@ApprovalPrincipal", SqlDbType.Decimal, borrowInfo.ApprovalPrincipal);
            DHelper.AddParameter(comm, "@InterestRate", SqlDbType.Float, borrowInfo.InterestRate);
            DHelper.AddParameter(comm, "@FinancingPeriods", SqlDbType.Int, borrowInfo.FinancingPeriods);
            DHelper.AddParameter(comm, "@RepaymentInterval", SqlDbType.Int, borrowInfo.RepaymentInterval);
            DHelper.AddParameter(comm, "@RepaymentMethod", SqlDbType.NVarChar, borrowInfo.RepaymentMethod);
            DHelper.AddParameter(comm, "@RepaymentDate", SqlDbType.Int, borrowInfo.RepaymentDate);
            DHelper.AddParameter(comm, "@FinanceAddDate", SqlDbType.DateTime, borrowInfo.FinanceAddDate);
            DHelper.AddParameter(comm, "@State", SqlDbType.NVarChar, borrowInfo.State);
            DHelper.AddParameter(comm, "@OncePayMonths", SqlDbType.Int, borrowInfo.OncePayMonths);
            DHelper.AddParameter(comm, "@FinalRatio", SqlDbType.Float, borrowInfo.FinalRatio);
            DHelper.AddParameter(comm, "@CustomerBailRatio", SqlDbType.Float, borrowInfo.CustomerBailRatio);
            DHelper.AddParameter(comm, "@FinalCost", SqlDbType.Decimal, borrowInfo.FinalCost);
            DHelper.AddParameter(comm, "@ExtralCost", SqlDbType.Decimal, borrowInfo.ExtralCost);

            return DHelper.ExecuteNonQuery(comm);
        }
    }
}
