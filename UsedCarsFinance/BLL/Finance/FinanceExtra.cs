using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Finance;

namespace BLL.Finance
{
    public class FinanceExtra
    {
        private static readonly DAL.Finance.FinanceExtraMapper FinanceExtraMapper = new DAL.Finance.FinanceExtraMapper();

        /// <summary>
        /// 查找
        /// </summary>
        /// zouql   16.08.30
        /// <param name="financeId">标识</param>
        /// <returns>FinanceExtraInfo</returns>
        public FinanceExtraInfo Get(int financeId)
        {
            return FinanceExtraMapper.Find(financeId);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// zouql   16.08.30
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool Add(FinanceExtraInfo value)
        {
            return FinanceExtraMapper.Insert(value) > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// zouql   16.08.30
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool Modify(FinanceExtraInfo value)
        {
            return FinanceExtraMapper.Update(value) > 0;
        }
    }
}
