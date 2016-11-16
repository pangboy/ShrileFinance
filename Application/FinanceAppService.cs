namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Finance;
    using Core.Entities.Produce;
    using Core.Interfaces.Repositories;
    using ViewModels.FinanceViewModels;

    /// <summary>
    /// 融资
    /// </summary>
    public class FinanceAppService
    {
        private readonly IFinanceRepository repository;
        private readonly AppUserManager userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceAppService" /> class.
        /// </summary>
        /// <param name="repository">融资仓储</param>
        /// <param name="userManager">用户管理</param>
        public FinanceAppService(IFinanceRepository repository, AppUserManager userManager)
        {
            this.repository = repository;

            this.userManager = userManager;
        }

        public void Create(FinanceApplyViewModel value)
        {
            var finance = Mapper.Map<Finance>(value);

            repository.Create(finance);
            repository.Commit();
        }

        public void Modify(FinanceApplyViewModel value)
        {
            var finance = Mapper.Map<Finance>(value);

            repository.Modify(finance);
            repository.Commit();
        }

        public FinanceApplyViewModel Get(Guid id)
        {
            var finance = repository.Get(id);

            FinanceApplyViewModel financeViewModel = Mapper.Map<FinanceApplyViewModel>(finance);
            return financeViewModel;
        }

        /// <summary>
        /// 通过融资标识获取信审ViewModel
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns>信审ViewModel</returns>
        public CreditExamineViewModel GetCreditExamineByFinanceId(Guid financeId)
        {
            if (financeId == null)
            {
                return null;
            }

            // 获取信审报告实体
            var finance = repository.Get(financeId);

            if (finance == null)
            {
                return null;
            }

            // 实体转ViewModel
            var creditExamineReportViewModel = Mapper.Map<CreditExamineViewModel>(finance.CreditExamine) ?? new CreditExamineViewModel();

            creditExamineReportViewModel.FinanceId = finance.Id;

            // 当前用户
            var user = userManager.CurrentUser();

            // 初审
            creditExamineReportViewModel.TrialPerson = new KeyValuePair<string, string>(finance.CreditExamine.TrialPerson.Id, finance.CreditExamine.TrialPerson.Name);

            // 复审
            creditExamineReportViewModel.ReviewPerson = new KeyValuePair<string, string>(finance.CreditExamine.ReviewPerson.Id, finance.CreditExamine.ReviewPerson.Name);

            // 审批
            creditExamineReportViewModel.ApprovePerson = new KeyValuePair<string, string>(finance.CreditExamine.ApprovePerson.Id, finance.CreditExamine.ApprovePerson.Name);

            // 终审
            creditExamineReportViewModel.FinalPerson = new KeyValuePair<string, string>(finance.CreditExamine.FinalPerson.Id, finance.CreditExamine.FinalPerson.Name);

            return creditExamineReportViewModel;
        }

        /// <summary>
        /// 编辑信审报告
        /// </summary>
        /// <param name="value">信审ViewModel</param>
        public void EditCreditExamine(CreditExamineViewModel value)
        {
            if (value == null || value.FinanceId == null)
            {
                return;
            }

            // 获取该信审对应的融资实体
            var finance = repository.Get(value.FinanceId);

            // 信审ViewModel转信审实体，更新信审
            finance.CreditExamine = Mapper.Map<CreditExamine>(value);

            // 初审
            finance.CreditExamine.TrialPerson.Id = value.TrialPerson.Key;
            finance.CreditExamine.TrialPerson.Name = value.TrialPerson.Value;

            // 复审
            finance.CreditExamine.ReviewPerson.Id = value.ReviewPerson.Key;
            finance.CreditExamine.ReviewPerson.Name = value.ReviewPerson.Value;

            // 审批
            finance.CreditExamine.ApprovePerson.Id = value.ApprovePerson.Key;
            finance.CreditExamine.ApprovePerson.Name = value.ApprovePerson.Value;

            // 终审
            finance.CreditExamine.FinalPerson.Id = value.FinalPerson.Key;
            finance.CreditExamine.FinalPerson.Name = value.FinalPerson.Value;

            repository.Modify(finance);

            // 执行修改
            repository.Commit();
        }

        /// <summary>
        /// 通过融资标识获取融资审核ViewModel
        /// </summary>
        /// <param name="financeId">信审标识</param>
        /// <returns>融资审核ViewModel</returns>
        public FinanceAuidtViewModel GetFinanceAuidtByFinanceId(Guid financeId)
        {
            if (financeId == null)
            {
                return null;
            }

            // 获取融资实体
            var finance = repository.Get(financeId);

            if (finance == null)
            {
                return null;
            }

            // 实体转ViewModel
            var financeAuditViewModel = new FinanceAuidtViewModel()
            {
                // 融资标识
                FinanceId = finance.Id,

                AdviceMoney = finance.AdviceMoney,

                AdviceRatio = finance.AdviceRatio,

                ApprovalMoney = finance.ApprovalMoney,

                ApprovalRatio = finance.ApprovalRatio,

                Payment = finance.Payment,

                Cost = finance.Cost,

                // 厂商指导价
                ManufacturerGuidePrice = finance.Vehicle.ManufacturerGuidePrice,

                // 融资项（Id、<Name_Maney>）
                FinancingItems = GetFinancingItems(finance)
            };

            return financeAuditViewModel;
        }

        /// <summary>
        /// 编辑融资审核
        /// </summary>
        /// <param name="value">融资审核ViewModel</param>
        public void EditFinanceAuidt(FinanceAuidtViewModel value)
        {
            if (value == null || value.FinanceId == null)
            {
                return;
            }

            // 获取该融资审核对应的融资实体
            var finance = repository.Get(value.FinanceId);

            if (finance == null)
            {
                return;
            }

            // 建议融资金额
            finance.AdviceMoney = value.AdviceMoney;

            // 建议融资比例
            finance.AdviceRatio = value.AdviceRatio;

            // 审批融资金额
            finance.ApprovalMoney = value.ApprovalMoney;

            // 审批融资比例
            finance.ApprovalRatio = value.ApprovalRatio;

            // 月供额度
            finance.Payment = value.Payment;

            // 手续费
            finance.Cost = value.Cost;

            // 初审 修改融资项各金额
            if (!value.IsReview)
            {
                // 修改融资项各金额
                finance.FinanceProduce = EditFinanceAuidts(financingItems: finance.FinanceProduce, financingItemCollection: value.FinancingItems);
            }

            repository.Modify(finance);

            // 执行修改
            repository.Commit();
        }

        /// <summary>
        /// 通过融资标识获取运营ViewModel
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns>运营ViewModel</returns>
        public OperationViewModel GetOperationByFinanceId(Guid financeId)
        {
            if (financeId == null)
            {
                return null;
            }

            // 获取信审报告实体
            var finance = repository.Get(financeId);

            if (finance == null)
            {
                return null;
            }

            // 实体转ViewModel
            var operationReportViewModel = Mapper.Map<OperationViewModel>(finance.FinanceExtension) ?? new OperationViewModel();

            operationReportViewModel.FinanceId = finance.Id;

            // 选择还款日
            operationReportViewModel.RepaymentDate = finance.RepaymentDate;

            // 首次租金支付日期
            operationReportViewModel.FirstPaymentDate = finance.RepayRentDate;

            // 保证金
            operationReportViewModel.Margin = finance.Bail;

            // 先付月供
            operationReportViewModel.PayMonthly = finance.Payment;

            // 一次性付息
            operationReportViewModel.OnePayInterest = finance.OnePayInterest;

            // 实际用款额
            operationReportViewModel.ActualAmount = finance.Principal;

            // 融资项
            operationReportViewModel.FinancingItems = GetFinancingItems(finance);

            return operationReportViewModel;
        }

        /// <summary>
        /// 编辑运营
        /// </summary>
        /// <param name="value">运营ViewModel</param>
        public void EditOperation(OperationViewModel value)
        {
            if (value == null || value.FinanceId == null)
            {
                return;
            }

            // 获取该信审对应的融资实体
            var finance = repository.Get(value.FinanceId);

            if (finance == null)
            {
                return;
            }

            // 选择还款日
            finance.RepaymentDate = value.RepaymentDate;

            // 首次租金支付日期
            finance.RepayRentDate = value.FirstPaymentDate;

            // 保证金
            finance.Bail = value.Margin;

            // 先付月供
            finance.Payment = value.PayMonthly;

            // 一次性付息
            finance.OnePayInterest = value.OnePayInterest;

            // 实际用款额
            finance.Principal = value.ActualAmount;

            if (finance.FinanceExtension == null)
            {
                finance.FinanceExtension = new FinanceExtension();
            }

            // 放款主体
            finance.FinanceExtension.LoanPrincipal = value.LoanPrincipal;

            // 放款账户
            finance.FinanceExtension.CreditAccountId = value.CreditAccountId;

            // 放款账户开户行
            finance.FinanceExtension.CreditBankName = value.CreditBankName;

            // 放款账户卡号
            finance.FinanceExtension.CreditBankCard = value.CreditBankCard;

            // 合同Json
            finance.FinanceExtension.ContactJson = value.ContactJson;

            repository.Modify(finance);

            // 执行修改
            repository.Commit();
        }

        /// <summary>
        ///  获取融资项
        /// </summary>
        /// <param name="finance">融资实体</param>
        /// <returns>融资项</returns>
        private ICollection<KeyValuePair<Guid, KeyValuePair<string, decimal?>>> GetFinancingItems(Finance finance)
        {
            var financingItems = new List<KeyValuePair<Guid, KeyValuePair<string, decimal?>>>();

            // 提取融资项
            finance.FinanceProduce.ToList().ForEach(delegate(FinanceProduce item)
            {
                financingItems.Add(new KeyValuePair<Guid, KeyValuePair<string, decimal?>>(item.Id, new KeyValuePair<string, decimal?>(item.Name, item.Money)));
            });

            return financingItems;
        }

        /// <summary>
        /// 修改融资项各金额
        /// </summary>
        /// <param name="financingItems">融资对应的融资项</param>
        /// <param name="financingItemCollection">前端传回的融资项</param>
        /// <returns></returns>
        private ICollection<FinanceProduce> EditFinanceAuidts(ICollection<FinanceProduce> financingItems, ICollection<KeyValuePair<Guid, KeyValuePair<string, decimal?>>> financingItemCollection)
        {
            var financingItemList = financingItems.ToList();

            // 更新融资项各金额
            financingItemList.ForEach(delegate(FinanceProduce financingItem)
            {
                // 获取融资项标识
                var key = financingItem.Id;

                // 更新指定融资项对应的金额
                financingItem.Money = financingItemCollection.Single(m => m.Key.Equals(key)).Value.Value.Value;
            });

            return financingItemList;
        }
    }
}
