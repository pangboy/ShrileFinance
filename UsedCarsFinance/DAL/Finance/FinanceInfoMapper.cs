using System;
using System.Data;
using System.Data.SqlClient;
using Models.Finance;

namespace DAL.Finance
{
    public class FinanceInfoMapper : AbstractMapper<FinanceInfo>
    {
        /// <summary>
        /// 查找
        /// </summary>
        /// qiy    16.03.31
        /// qiy    16.05.31
        /// yangj   16.07.26    新增融资预估金额字段
        /// zouql   16.07.28    新增厂商指导价字段
        /// zouql   16.07.29    新增保证金、先付月供金额、一次性付息金额、实际用款金额字段
        /// zouql   16.08.02    增加建议融资金额
        /// zouql   16.08.04    新增融资实际金额字段
        /// <param name="id">标识</param>
        /// <returns></returns>
        public FinanceInfo Find(int id)
        {
            string findStatement =
              @"SELECT 
                    FinanceId, ProduceId, Type, IntentionPrincipal, 
                    ApprovalValue,
                    Remarks, OncePayMonths ,
                    CreateBy,CreateOf,
                    MarginMoney,PaymonthlyMoney,
                    OnepayInterestMoney,ActualcashMoney
                FROM FANC_FinanceInfo 
                WHERE FinanceId = @ID";

            return AbstractFind(findStatement, id);
        }

        /// <summary>
        /// 查找AddDate
        /// </summary>
        /// zouql   16.08.31
        /// <param name="id">标识</param>
        /// <returns>AddDate</returns>
        public DateTime FindAddDate(int id)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
              SELECT 
                    AddDate
                FROM FANC_FinanceInfo 
                WHERE FinanceId = @ID"
            );

            DHelper.AddParameter(comm, "@ID", SqlDbType.Int, id);

            return Convert.ToDateTime(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// qiy    16.03.31
        /// qiy    16.05.31
        /// yangj   16.07.26    新增融资预估金额字段
        /// zouql   16.07.29    新增保证金、先付月供金额、一次性付息金额、实际用款金额字段
        /// zouql   16.08.02    增加建议融资金额
        /// zouql   16.08.04    新增融资实际金额字段
        /// <param name="value">值</param>
        public void Insert(FinanceInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO FANC_FinanceInfo (
                    ProduceId, 
                    Type, 
                    IntentionPrincipal,
                    ApprovalValue,
                    CreateBy,
                    CreateOf, 
                    AddDate,
                    Remarks,
                    OncePayMonths, 
                    MarginMoney,
                    PaymonthlyMoney,
                    OnepayInterestMoney,
                    ActualcashMoney
                    )
				VALUES (
                    @ProduceId,
                    @Type, 
                    @IntentionPrincipal,
                    @ApprovalValue, 
                    @CreateBy,
                    @CreateOf,
                    DEFAULT, 
                    @Remarks,
                    @OncePayMonths,
                    @MarginMoney,
                    @PaymonthlyMoney,
                    @OnepayInterestMoney,
                    @ActualcashMoney
                    ) 
                SELECT SCOPE_IDENTITY()
			");
            DHelper.AddParameter(comm, "@ProduceId", SqlDbType.Int, value.ProduceId);
            DHelper.AddParameter(comm, "@Type", SqlDbType.TinyInt, value.Type);
            DHelper.AddParameter(comm, "@IntentionPrincipal", SqlDbType.Decimal, value.IntentionPrincipal);
            DHelper.AddParameter(comm, "@ApprovalValue", SqlDbType.Decimal, value.ApprovalValue);
            DHelper.AddParameter(comm, "@CreateBy", SqlDbType.Int, value.CreateBy);
            DHelper.AddParameter(comm, "@CreateOf", SqlDbType.Int, value.CreateOf);
            DHelper.AddParameter(comm, "@Remarks", SqlDbType.NVarChar, value.Remarks);
            DHelper.AddParameter(comm, "@OncePayMonths", SqlDbType.Int, value.OncePayMonths);

            // 保证金、先付月供金额、一次性付息金额、实际用款金额
            DHelper.AddParameter(comm, "@MarginMoney", SqlDbType.Decimal, value.MarginMoney);
            DHelper.AddParameter(comm, "@PaymonthlyMoney", SqlDbType.Decimal, value.PaymonthlyMoney);
            DHelper.AddParameter(comm, "@OnepayInterestMoney", SqlDbType.Decimal, value.OnepayInterestMoney);
            DHelper.AddParameter(comm, "@ActualcashMoney", SqlDbType.Decimal, value.ActualcashMoney);

            value.FinanceId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// qiy    16.03.31
        /// qiy    16.05.31
        /// yangj   16.07.26    新增融资预估金额字段
        /// zouql   16.07.28    新增厂商指导价字段
        /// zouql   16.08.04    新增融资实际金额字段
        /// <param name="value">值</param>
        /// <returns></returns>
        public int Update(FinanceInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				UPDATE FANC_FinanceInfo SET 
					ProduceId = @ProduceId,
					Type = @Type,
					IntentionPrincipal = @IntentionPrincipal,
					ApprovalValue = @ApprovalValue,  
					Remarks = @Remarks ,
                    OncePayMonths=@OncePayMonths,
                    MarginMoney=@MarginMoney,
                    PaymonthlyMoney=@PaymonthlyMoney,
                    OnepayInterestMoney=@OnepayInterestMoney,
                    ActualcashMoney=@ActualcashMoney
				WHERE FinanceId = @FinanceId
			");
            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, value.FinanceId);
            DHelper.AddParameter(comm, "@ProduceId", SqlDbType.Int, value.ProduceId);
            DHelper.AddParameter(comm, "@Type", SqlDbType.TinyInt, value.Type);

            // 建议融资金额
            DHelper.AddParameter(comm, "@IntentionPrincipal", SqlDbType.Decimal, value.IntentionPrincipal);
            DHelper.AddParameter(comm, "@ApprovalValue", SqlDbType.Decimal, value.ApprovalValue);
            DHelper.AddParameter(comm, "@Remarks", SqlDbType.NVarChar, value.Remarks);
            DHelper.AddParameter(comm, "@OncePayMonths", SqlDbType.Int, value.OncePayMonths);

            // 保证金、先付月供金额、一次性付息金额、实际用款金额
            DHelper.AddParameter(comm, "@MarginMoney", SqlDbType.Decimal, value.MarginMoney);
            DHelper.AddParameter(comm, "@PaymonthlyMoney", SqlDbType.Decimal, value.PaymonthlyMoney);
            DHelper.AddParameter(comm, "@OnepayInterestMoney", SqlDbType.Decimal, value.OnepayInterestMoney);
            DHelper.AddParameter(comm, "@ActualcashMoney", SqlDbType.Decimal, value.ActualcashMoney);

            return DHelper.ExecuteNonQuery(comm);
        }
    }
}
