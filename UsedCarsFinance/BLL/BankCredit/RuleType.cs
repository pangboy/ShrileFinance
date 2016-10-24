using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.BankCredit;


namespace BLL.BankCredit
{
    public class RuleType
    {
        private static readonly DAL.BankCredit.RuleTypeMapper RuleTypeMapper = new DAL.BankCredit.RuleTypeMapper();

        /// <summary>
        /// 查找
        /// zouql   16.09.20
        /// </summary>
        /// <param name="ruleTypeId">标识</param>
        /// <returns>实体</returns>
        public RuleTypeInfo Get(int ruleTypeId)
        {
            return RuleTypeMapper.Find(ruleTypeId);
        }

        /// <summary>
        /// 插入
        /// zouql   16.09.20
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>结果</returns>
        public bool Add(RuleTypeInfo value)
        {
            return RuleTypeMapper.Insert(value)>0;
        }

        /// <summary>
        /// 更新
        /// zouql   16.09.20
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>结果</returns>
        public bool Modify(RuleTypeInfo value)
        {
            return RuleTypeMapper.Update(value)>0;
        }
    }
}
