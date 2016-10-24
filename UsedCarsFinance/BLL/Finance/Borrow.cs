using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Finance;

namespace BLL.Finance
{
    public class Borrow
    {
        private static readonly DAL.Finance.BorrowMapper BorrowMapper = new DAL.Finance.BorrowMapper();
        private static readonly DAL.Produce.ProduceMapper ProduceMapper = new DAL.Produce.ProduceMapper();
        private static readonly DAL.Finance.FinanceInfoMapper FinanceMapper = new DAL.Finance.FinanceInfoMapper();
        private static readonly DAL.Finance.ReviewMapper ReviewMapper = new DAL.Finance.ReviewMapper();

        /// <summary>
        /// 查找指定的借贷信息
        /// </summary>
        /// zouql   16.08.30
        /// <param name="financeId">融资标识</param>
        /// <returns>借贷信息</returns>
        public BorrowInfo Get(int financeId)
        {
            var borrowInfo = BorrowMapper.Find(financeId);

            // 当前期数
            borrowInfo.CurrentMonths = borrowInfo.OncePayMonths + 1;

            // 余额(暂缺，实现余额计算方法后补上)
            //// borrowInfo.Balance=

            return borrowInfo;
        }

        /// <summary>
        /// 查找所有借贷信息
        /// </summary>
        /// zouql   16.08.30
        /// <returns>借贷信息List</returns>
        public List<BorrowInfo> GetAll()
        {
            var borrowInfoList = BorrowMapper.FindAll();

            borrowInfoList.ForEach(delegate(BorrowInfo item)
            {
                // 当前期数
                item.CurrentMonths = item.OncePayMonths + 1;

                // 余额(暂缺，实现余额计算方法后补上)
                //// item.Balance=
            }

            );

            return BorrowMapper.FindAll();
        }

        /// <summary>
        /// 插入指定的借贷信息
        /// </summary>
        /// zouql   16.08.30
        /// yangj   16.09.10    修改字段
        /// <param name="financeId">融资标识</param>
        /// <returns>操作结果</returns>
        public bool Add(int financeId)
        {
            // 获取融资信息
            var finance = FinanceMapper.Find(financeId);
            var review = ReviewMapper.Find(financeId);

            // 获取产品信息
            var product = ProduceMapper.FindByProduce_Id(finance.ProduceId);

            // 实例化BorrowInfo
            var borrowInfo = new BorrowInfo() { FinanceId = financeId };

            // BorrowInfo赋值
            borrowInfo.ApprovalPrincipal = review.ApprovalPrincipal;
            borrowInfo.InterestRate = product.InterestRate;
            borrowInfo.FinancingPeriods = product.FinancingPeriods;
            borrowInfo.RepaymentInterval = product.RepaymentInterval;
            borrowInfo.RepaymentMethod = product.RepaymentMethod;
            borrowInfo.RepaymentDate = review.RepaymentDate;
            borrowInfo.FinanceAddDate = FinanceMapper.FindAddDate(borrowInfo.FinanceId);
            borrowInfo.OncePayMonths = finance.OncePayMonths.Value;
            borrowInfo.FinalRatio = product.FinalRatio;
            borrowInfo.CustomerBailRatio = product.CustomerBailRatio;
            borrowInfo.FinalCost = review.FinalCost;
            borrowInfo.ExtralCost = product.AdditionalGPSCost + product.AdditionalOtherCost;

            return BorrowMapper.Insert(borrowInfo) > 0;
        }

        /// <summary>
        /// 跟新指定的借贷信息
        /// </summary>
        /// zouql   16.08.30
        /// <param name="borrowInfo">借贷信息</param>
        /// <returns>操作结果</returns>
        public bool Moddify(BorrowInfo borrowInfo)
        {
            return BorrowMapper.Update(borrowInfo) > 0;
        }
    }
}
