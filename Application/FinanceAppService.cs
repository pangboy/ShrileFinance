namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Finance;
    using Core.Entities.Identity;
    using Core.Interfaces.Repositories;
    using ViewModels.FinanceViewModels;
    using System.Collections;
    using System.Reflection;

    /// <summary>
    /// 融资
    /// </summary>
    public class FinanceAppService
    {
        private readonly IFinanceRepository repository;
        private readonly AppUserManager userManager;
        private readonly AppRoleManager roleManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceAppService" /> class.
        /// </summary>
        /// <param name="repository">融资仓储</param>
        /// <param name="userManager">用户管理</param>
        /// <param name="roleManager">角色管理</param>
        public FinanceAppService(IFinanceRepository repository, AppUserManager userManager, AppRoleManager roleManager)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void Create(FinanceApplyViewModel value)
        {
            var finance = Mapper.Map<Finance>(value);

            finance.Produce = null;
            repository.Create(finance);
            repository.Commit();
        }

        public void Modify(FinanceApplyViewModel model)
        {
            var finance = repository.Get(model.Id.Value);
            Mapper.Map(model, finance);

            new UpdateBind().Bind(finance.FinanceProduce, model.FinanceProduce);
            new UpdateBind().Bind(finance.Applicant, model.Applicant);

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

            // 获取融资实体
            var finance = repository.Get(financeId);

            if (finance == null)
            {
                return null;
            }

            // 当前用户
            var curentUser = userManager.CurrentUser();

            if (curentUser == null)
            {
                return null;
            }

            finance.CreditExamine = finance.CreditExamine ?? new CreditExamine();

            // 实体转ViewModel
            var creditExamineReportViewModel = Mapper.Map<CreditExamineViewModel>(finance.CreditExamine);

            // 融资标识
            creditExamineReportViewModel.FinanceId = finance.Id;

            // 保证金
            if (!string.IsNullOrEmpty(finance.CreditExamine.Margin))
            {
                var array = finance.CreditExamine.Margin.Split('-');
                creditExamineReportViewModel.Margin1 = array[0];
                creditExamineReportViewModel.Margin2 = array[1];
            }

            // 产品编号
            creditExamineReportViewModel.ProductNumber = finance.Produce.Code;

            // 产品详解
            creditExamineReportViewModel.ProductExplain = finance.Produce.Remarks;

            // 产品种类
            creditExamineReportViewModel.ProductCategorie = finance.Vehicle.BusinessType.ToString();

            // 承租人
            var lessee = finance.Applicant.ToList().Find(m => m.Type == Applicant.TypeEnum.主要申请人);
            creditExamineReportViewModel.LesseeName = lessee.Name;
            creditExamineReportViewModel.LesseeIdCard = lessee.IdentityType.Equals("身份证") ? lessee.Identity : null;
            creditExamineReportViewModel.LesseeMobile = lessee.Mobile;

            // 共借人
            creditExamineReportViewModel.CommonBorrwerName1 = finance.Applicant.ToList().Find(m => m.Type == Applicant.TypeEnum.共同申请人).Name;

            // 保证人
            creditExamineReportViewModel.Guarantor1 = finance.Applicant.ToList().Find(m => m.Type == Applicant.TypeEnum.担保人).Name;

            // 当前角色
            var curentRole = roleManager.FindByIdAsync(curentUser.RoleId).Result;

            if (curentRole != null)
            {
                var trialUser = finance.CreditExamine.TrialUser ?? new AppUser();
                var reviewUser = finance.CreditExamine.ReviewUser ?? new AppUser();
                var approveUser = finance.CreditExamine.ApproveUser ?? new AppUser();
                var finalUser = finance.CreditExamine.FinalUser ?? new AppUser();

                creditExamineReportViewModel.TrialPerson = new KeyValuePair<string, string>(trialUser.Id, trialUser.UserName);
                creditExamineReportViewModel.ReviewPerson = new KeyValuePair<string, string>(reviewUser.Id, reviewUser.Name);
                creditExamineReportViewModel.ApprovePerson = new KeyValuePair<string, string>(approveUser.Id, approveUser.Name);
                creditExamineReportViewModel.FinalPerson = new KeyValuePair<string, string>(finalUser.Id, finalUser.Name);

                if (curentRole.Name.Equals("初审员"))
                {
                    creditExamineReportViewModel.TrialPerson = new KeyValuePair<string, string>(trialUser.Id, trialUser.UserName);
                }
                else if (curentRole.Name.Equals("复审员"))
                {
                    creditExamineReportViewModel.ReviewPerson = new KeyValuePair<string, string>(reviewUser.Id, reviewUser.Name);
                }
                else if (curentRole.Name.Equals("审批员"))
                {
                    creditExamineReportViewModel.ApprovePerson = new KeyValuePair<string, string>(approveUser.Id, approveUser.Name);
                }
                else if (curentRole.Name.Equals("终审员"))
                {
                    creditExamineReportViewModel.FinalPerson = new KeyValuePair<string, string>(finalUser.Id, finalUser.Name);
                }
            }

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

            if (finance == null)
            {
                return;
            }

            // 当前用户
            var curentUser = userManager.CurrentUser();

            if (curentUser == null)
            {
                return;
            }

            finance.CreditExamine = finance.CreditExamine ?? new CreditExamine();

            // 信审ViewModel转信审实体，更新信审
            Mapper.Map(value, finance.CreditExamine);

            // 保证金
            finance.CreditExamine.Margin = value.Margin1 + "-" + value.Margin2;

            // 当前角色
            var curentRole = roleManager.FindByIdAsync(curentUser.RoleId).Result;

            if (curentRole.Name.Equals("初审员"))
            {
                finance.CreditExamine.TrialUser = curentUser;
            }
            else if (curentRole.Name.Equals("复审员"))
            {
                finance.CreditExamine.ReviewUser = curentUser;
            }
            else if (curentRole.Name.Equals("审批员"))
            {
                finance.CreditExamine.ReviewUser = curentUser;
            }
            else if (curentRole.Name.Equals("终审员"))
            {
                finance.CreditExamine.ReviewUser = curentUser;
            }

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
            operationReportViewModel.RepayRentDate = finance.RepayRentDate;

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

            // 车辆补充信息
            var array = new string[] { "RegisterDate", "RunningMiles", "FactoryDate", "BusinessType", "PlateNo", "FrameNo", "EngineNo", "RegisterCity", "Condition" };
            operationReportViewModel = PartialMapper(finance.Vehicle,operationReportViewModel);

            ////operationReportViewModel.RegisterDate = finance.Vehicle.RegisterDate;
            ////operationReportViewModel.RunningMiles = finance.Vehicle.RunningMiles;
            ////operationReportViewModel.FactoryDate = finance.Vehicle.FactoryDate;
            ////operationReportViewModel.BusinessType = finance.Vehicle.BusinessType;

            ////operationReportViewModel.PlateNo = finance.Vehicle.PlateNo;
            ////operationReportViewModel.FrameNo = finance.Vehicle.FrameNo;
            ////operationReportViewModel.EngineNo = finance.Vehicle.EngineNo;
            ////operationReportViewModel.RegisterCity = finance.Vehicle.RegisterCity;
            ////operationReportViewModel.Condition = finance.Vehicle.Condition;

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

            if (finance.FinanceExtension == null)
            {
                finance.FinanceExtension = new FinanceExtension();
            }

            if (value.NodeType.Equals("Customer"))
            {
                // 还款信息
                finance.FinanceExtension.CustomerAccountName = value.CustomerAccountName;
                finance.FinanceExtension.CustomerBankName = value.CustomerBankName;
                finance.FinanceExtension.CustomerBankCard = value.CustomerBankCard;

                if (!finance.FinanceExtension.LoanPrincipal.Equals("Channel"))
                {
                    // 放款信息
                    finance.FinanceExtension.CreditAccountName = value.CreditAccountName;
                    finance.FinanceExtension.CreditBankName = value.CreditBankName;
                    finance.FinanceExtension.CreditBankCard = value.CreditBankCard;
                }

                // 车辆补充信息
                finance.Vehicle.PlateNo = value.PlateNo;
                finance.Vehicle.FrameNo = value.FrameNo;
                finance.Vehicle.EngineNo = value.EngineNo;
                finance.Vehicle.RegisterDate = value.RegisterDate;
                finance.Vehicle.RunningMiles = value.RunningMiles;
                finance.Vehicle.FactoryDate = value.FactoryDate;
                finance.Vehicle.BusinessType = value.BusinessType;
                finance.Vehicle.RegisterCity = value.RegisterCity;
                finance.Vehicle.Condition = value.Condition;
            }
            else
            {
                // 选择还款日
                finance.RepaymentDate = value.RepaymentDate;

                // 首次租金支付日期
                finance.RepayRentDate = value.RepayRentDate;

                // 保证金
                finance.Bail = value.Margin;

                // 先付月供
                finance.Payment = value.PayMonthly;

                // 一次性付息
                finance.OnePayInterest = value.OnePayInterest;

                // 实际用款额
                finance.Principal = value.ActualAmount;

                // 放款主体
                finance.FinanceExtension.LoanPrincipal = value.LoanPrincipal;

                // 放款账户
                finance.FinanceExtension.CreditAccountName = value.CreditAccountName;

                // 放款账户开户行
                finance.FinanceExtension.CreditBankName = value.CreditBankName;

                // 放款账户卡号
                finance.FinanceExtension.CreditBankCard = value.CreditBankCard;

                // 合同Json
                finance.FinanceExtension.ContactJson = value.ContactJson;
            }

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
            finance.FinanceProduce.ToList().ForEach(delegate (FinanceProduce item)
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
            financingItemList.ForEach(delegate (FinanceProduce financingItem)
            {
                // 获取融资项标识
                var key = financingItem.Id;

                // 更新指定融资项对应的金额
                financingItem.Money = financingItemCollection.Single(m => m.Key.Equals(key)).Value.Value.Value;
            });

            return financingItemList;
        }

        /// <summary>
        /// 映射类
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <typeparam name="T1">类型</typeparam>
        /// <param name="refObj">输入对象</param>
        /// <param name="outObj">输出对象</param>
        /// <param name="array">属性名数组</param>
        /// <returns></returns>
        private T1 PartialMapper<T, T1>(T refObj, T1 outObj, string[] array = null)
        {
            if (refObj == null)
            {
                return outObj;
            }

            if (outObj == null)
            {
                outObj = Activator.CreateInstance<T1>();
            }

            // 字典记录属性的值
            var container = new Dictionary<object, object>();
            refObj.GetType().GetProperties(BindingFlags.Public).ToList().ForEach(delegate (PropertyInfo item)
            {
                if (array == null || array.Contains(item.Name))
                {
                    container.Add(item.Name, item.GetValue(refObj));
                }
            });

            // 字典为空，则返回
            if (container.Keys.Count == 0)
            {
                return outObj;
            }

            // 从字典取值，并对输出对象对应的属性赋值
            foreach (PropertyInfo item in outObj.GetType().GetProperties(BindingFlags.Public))
            {
                if (array == null || array.Contains(item.Name))
                {
                    if (container.Keys.Contains(item.Name))
                    {
                        item.SetValue(outObj, container[item.Name], null);

                        container.Remove(item.Name);
                    }
                }
            }

            return outObj;
        }
    }
}


