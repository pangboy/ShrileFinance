using Model;
using Model.Produce;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;

namespace BLL.Produce
{
    public class Produce
    {
        private readonly static DAL.Produce.ProduceMapper produceMapper = new DAL.Produce.ProduceMapper();

        /// <summary>
        /// 产品列表查询方法
        /// </summary>
        /// cais    16.03.28
        /// <param name="pagination">分页</param>
        /// <param name="filter">参数</param>
        /// <returns>dt</returns>

        public DataTable List(Model.Pagination pagination, NameValueCollection filter)
        {
            return produceMapper.Find(pagination, filter);
        }

        /// <summary>
        /// 通过一个产品ID，返回一个产品
        /// </summary>
        /// cais    16.03.28
        /// <param name="produceId"></param>
        /// <returns></returns>
        public ProduceInfo Get(int produceId)
        {
            return produceMapper.FindByProduce_Id(produceId);
        }

        /// <summary>
        /// 通过实体，增加一个产品
        /// </summary>
        /// cais    16.03.28
        /// <param name="Value"></param>
        /// <returns></returns>
        public bool Add(ProduceInfo Value)
        {
            bool add = false;
            bool adopt = true;

            List<ComboInfo> Codelist = produceMapper.Option();

            foreach (var code in Codelist)
            {
                if (Value.Code == code.text || Value.Code.Length > 100)
                {
                    adopt = false;
                }
            }

            if (adopt == true) produceMapper.Insert(Value);

            if (Value.ProduceId > 0) add = true;

            return add;
        }

        /// <summary>
        /// 根据一个产品ID ，修改对应的产品
        /// </summary>
        /// cais    16.03.29
        /// yangj   16.07.25(新增融资范围)
        /// yand    16.07.25(增加费率)
        /// <param name="Value"></param>
        /// <returns></returns>
        public bool Modify(ProduceInfo Value)
        {
            bool modify = false;

            ProduceInfo produce = produceMapper.FindByProduce_Id(Value.ProduceId); ;

            if (Value == null) return false;

            produce.ProduceId = Value.ProduceId;
            produce.Code = Value.Code;
            produce.Name = Value.Name;
            produce.InterestRate = Value.InterestRate;
            produce.RepaymentMethod = Value.RepaymentMethod;
            produce.MinFinancingRatio = Value.MinFinancingRatio;
            produce.MaxFinancingRatio = Value.MaxFinancingRatio;
            produce.FinalRatio = Value.FinalRatio;
            produce.FinancingPeriods = Value.FinancingPeriods;
            produce.RepaymentInterval = Value.RepaymentInterval;
            produce.CustomerBailRatio = Value.CustomerBailRatio;
            produce.CustomerPoundage = Value.CustomerPoundage;
            produce.Remarks = Value.Remarks;
            produce.AdditionalGPSCost = Value.AdditionalGPSCost;
            produce.AdditionalOtherCost = Value.AdditionalOtherCost;
            // 新增融资范围
            produce.IsVehiclePrice = Value.IsVehiclePrice;
            produce.IsPurchaseTax = Value.IsPurchaseTax;
            produce.IsBusinessInsurance = Value.IsBusinessInsurance;
            produce.IsTafficCompulsoryInsurance = Value.IsTafficCompulsoryInsurance;
            produce.IsVehicleVesselTax = Value.IsVehicleVesselTax;
            produce.IsExtendedWarrantyInsurance = Value.IsExtendedWarrantyInsurance;
            produce.IsOther = Value.IsOther;

            //增加费率
            produce.Rate = Value.Rate;
            if (produceMapper.Update(produce) > 0)
            {
                modify = true;
            }

            return modify;
        }

        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// cais    16.03.28
        /// <returns></returns>
        public List<ComboInfo> Option()
        {
            return produceMapper.Option();
        }

        /// <summary>
        /// 将产品转换为选项
        /// </summary>
        /// qiy     16.04.07
        /// <param name="produces">产品列表</param>
        /// <returns></returns>
        public static List<ComboInfo> ProducesToOption(List<ProduceInfo> produces)
        {
            List<ComboInfo> options = new List<ComboInfo>();

            foreach (var produce in produces)
            {
                options.Add(new ComboInfo(produce.ProduceId.ToString(), produce.Code));
            }

            return options;
        }


        /// <summary>
        /// 获取产品列表（还款方式）
        /// </summary>
        /// yangj   16.08.02
        /// <returns></returns>
        public List<ComboInfo> GetByRepaymentMethod()
        {
            Credit.Credit _credit = new Credit.Credit();
            Credit.Account _creditAccount = new Credit.Account();

            //获取当前登录用户并借此查询授信主体标识
            int userId = User.User.CurrentUserId;
            var creditAccount = _creditAccount.Get(userId);

            if (creditAccount == null || creditAccount.CreditId == 0)
                return null;

            return produceMapper.FindByRepaymentMethod(creditAccount.CreditId);
        }

        /// <summary>
        /// 获取产品列表（产品名）
        /// </summary>
        /// yangj   16.08.02
        /// <returns></returns>
        public List<ComboInfo> GetByProduceName()
        {
            Credit.Credit _credit = new Credit.Credit();
            Credit.Account _creditAccount = new Credit.Account();

            //获取当前登录用户并借此查询授信主体标识
            int userId = User.User.CurrentUserId;
            var creditAccount = _creditAccount.Get(userId);

            if (creditAccount == null || creditAccount.CreditId == 0)
                return null;

            return produceMapper.FindByProduceName(creditAccount.CreditId);
        }

        /// <summary>
        /// 获取产品列表（融资期限）
        /// </summary>
        /// yangj   16.08.02
        /// <returns></returns>
        public List<ComboInfo> GetByFinancingPeriods()
        {
            Credit.Credit _credit = new Credit.Credit();
            Credit.Account _creditAccount = new Credit.Account();

            //获取当前登录用户并借此查询授信主体标识
            int userId = User.User.CurrentUserId;
            var creditAccount = _creditAccount.Get(userId);

            if (creditAccount == null || creditAccount.CreditId == 0)
                return null;

            return produceMapper.FindByFinancingPeriods(creditAccount.CreditId);
        }

        /// <summary>
        /// 产品筛选
        /// </summary>
        /// yangj   16.08.02
        /// <param name="produceName">产品名</param>
        /// <param name="repaymentMethod">还款方式</param>
        /// <param name="financingPeriods">融资期限</param>
        /// <returns></returns>
        public List<ComboInfo> GetProduct(string produceName, string repaymentMethod, string financingPeriods)
        {
            Credit.Credit _credit = new Credit.Credit();
            Credit.Account _creditAccount = new Credit.Account();

            //获取当前登录用户并借此查询授信主体标识
            int userId = User.User.CurrentUserId;
            var creditAccount = _creditAccount.Get(userId);

            if (creditAccount == null || creditAccount.CreditId == 0)
                return null;

            return produceMapper.FindProduct(produceName, repaymentMethod, financingPeriods, creditAccount.CreditId);
        }
    }
}