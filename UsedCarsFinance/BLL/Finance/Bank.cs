using Model.Finance;
using System.Collections.Generic;

namespace BLL.Finance
{
    public class Bank
    {
        private static readonly DAL.Finance.BankInfoMapper bankMapper = new DAL.Finance.BankInfoMapper();

        /// <summary>
        /// 添加
        /// </summary>
        /// zouql   16.07.26
        /// <param name="bankInfo">账户</param>
        /// <returns>添加结果</returns>
        public bool Add(BankInfo bankInfo)
        {
            bankMapper.Insert(bankInfo);
            return bankInfo.BankId > 0;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// zouql   16.07.26
        /// <param name="financeId">流程</param>
        /// <returns>查询结果</returns>
        public List<BankInfo> List(int financeId)
        {
            return bankMapper.List(financeId);
        }
    }
}
