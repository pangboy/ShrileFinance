using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models.BankCredit;

namespace DAL.BankCredit
{
    public class RuleTypeMapper : BankAbstractMapper<RuleTypeInfo>
    {
        /// <summary>
        /// 查找
        /// zouql   16.09.20
        /// </summary>
        /// <param name="ruleTypeId">标识</param>
        /// <returns>实体</returns>
        public RuleTypeInfo Find(int ruleTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
             SELECT * FROM BANK_RuleType WHERE RuleTypeId=@RuleTypeId
             ");
            DHelper.AddInParameter(comm, "@RuleTypeId", SqlDbType.Int, ruleTypeId);

            return Load(DHelper.ExecuteDataTable(comm));
        }

        /// <summary>
        /// 插入
        /// zouql   16.09.20
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>结果</returns>
        public int Insert(RuleTypeInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
             INSERT INTO BANK_RuleType ( RuleTypeId,MoneyType,TimeType,IntegerType )
             VALUES (@RuleTypeId,@MoneyType,@TimeType,@IntegerType ) SELECT SCOPE_IDENTITY()
             ");
            DHelper.AddInParameter(comm, "@RuleTypeId", SqlDbType.Int, value.RuleTypeId);
            DHelper.AddInParameter(comm, "@MoneyType", SqlDbType.Bit,value.MoneyType);
            DHelper.AddInParameter(comm, "@TimeType", SqlDbType.Bit, value.TimeType);
            DHelper.AddInParameter(comm, "@IntegerType", SqlDbType.Bit, value.IntegerType);

            return Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 更新
        /// zouql   16.09.20
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>结果</returns>
        public int Update(RuleTypeInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
             UPDATE BANK_RuleType SET
             MoneyType = @MoneyType, TimeType = @TimeType, IntegerType = @IntegerType,
             WHERE RuleTypeId = @RuleTypeId
             ");
            DHelper.AddInParameter(comm, "@RuleTypeId", SqlDbType.Int, value.RuleTypeId);
            DHelper.AddInParameter(comm, "@MoneyType", SqlDbType.Bit, value.MoneyType);
            DHelper.AddInParameter(comm, "@TimeType", SqlDbType.Bit, value.TimeType);
            DHelper.AddInParameter(comm, "@IntegerType", SqlDbType.Bit, value.IntegerType);

            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));
        }
    }
}
