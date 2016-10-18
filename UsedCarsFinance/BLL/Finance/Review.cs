using Model.Finance;

namespace BLL.Finance
{
    public class Review
    {
        private static readonly DAL.Finance.ReviewMapper ReviewInfoMapper = new DAL.Finance.ReviewMapper();

        /// <summary>
        /// 查找
        /// </summary>
        /// yangj   16.08.30
        /// <param name="financeId">标识</param>
        /// <returns>FinanceExtraInfo</returns>
        public ReviewInfo Get(int financeId)
        {
            return ReviewInfoMapper.Find(financeId);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// yangj   16.08.30
        /// <param name="value">审核实体</param>
        /// <returns></returns>
        public bool Add(ReviewInfo value)
        {
            return ReviewInfoMapper.Insert(value) > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yangj   16.08.30
        /// <param name="value">审核实体</param>
        /// <returns></returns>
        public bool Modify(ReviewInfo value)
        {
            return ReviewInfoMapper.Update(value) > 0;
        }
    }
}
