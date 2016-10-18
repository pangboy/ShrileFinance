using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BankCredit
{
    /// <summary>
    /// RuleType
    /// zouql   16.09.20
    /// </summary>
    public class RuleTypeInfo
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int RuleTypeId { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public bool MoneyType { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public bool TimeType { get; set; }

        /// <summary>
        /// 整数
        /// </summary>
        public bool IntegerType { get; set; }
    }
}
