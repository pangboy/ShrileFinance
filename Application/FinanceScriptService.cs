namespace Application
{
    using System.Linq;
    using Core.Entities.Flow;
    using Core.Interfaces.Repositories;
    using Newtonsoft.Json.Linq;
    using ViewModels.FinanceViewModels;

    public class FinanceScriptAppService
    {
        private readonly FinanceAppService financeAppService;

        public FinanceScriptAppService(FinanceAppService financeAppService)
        {
            this.financeAppService = financeAppService;
        }

        public Instance Instance { get; set; }

        public JObject Data { get; set; }

        /// <summary>
        /// 融资申请
        /// </summary>
        public void FinanceApply()
        {
            // 获取数据
            var finance = GetData<FinanceApplyViewModel>("57DC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 创建或修改
            if (finance.Id.HasValue)
            {
                financeAppService.Modify(finance);
            }
            else
            {
                financeAppService.Create(finance);

                // 设置流程实例关联的业务标识
                Instance.RootKey = finance.Id;
            }

            // 如果执行失败则抛出异常, 或用返回值表示结果.
            if (false)
            {
                throw new Core.Exceptions.InvalidOperationAppException("保存失败.");
            }

            Instance.Title = $"{finance.Applicant.First(m => m.Type == ApplicationViewModel.TypeEnum.主要申请人).Name} - {finance.Vehicle.PlateNo}";
        }

        /// <summary>
        /// 融资审核
        /// </summary>
        public void FinanceAudit()
        {
            // 获取融资审核数据
            var financeAudit = GetData<FinanceAuidtViewModel>("58DC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 创建融资审核
            financeAppService.EditFinanceAuidt(financeAudit);

            // 获取信审数据
            var financeCreditExmine = GetData<CreditExamineViewModel>("59DC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 创建信审
            financeAppService.EditCreditExamine(financeCreditExmine);

            // 修改信审审核人
            financeAppService.SetApprover(financeAudit.FinanceId);

            // 如果执行失败则抛出异常, 或用返回值表示结果.
            if (false)
            {
                throw new Core.Exceptions.InvalidOperationAppException("保存失败.");
            }
        }

        /// <summary>
        /// 融资复审
        /// </summary>
        public void FinanceReaudit()
        {
            // 获取融资审核数据
            var financeAudit = GetData<FinanceAuidtViewModel>("58DC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 修改融资审核
            financeAppService.EditFinanceAuidt(financeAudit);

            // 修改信审审核人
            financeAppService.SetApprover(financeAudit.FinanceId);

            // 如果执行失败则抛出异常, 或用返回值表示结果.
            if (false)
            {
                throw new Core.Exceptions.InvalidOperationAppException("保存失败.");
            }
        }

        /// <summary>
        /// 运营补充
        /// </summary>
        public void FinanceOperation()
        {
            // 获取数据
            var finance = GetData<OperationViewModel>("5ADC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 创建或修改
            financeAppService.EditOperation(finance);

            // 如果执行失败则抛出异常, 或用返回值表示结果.
            if (false)
            {
                throw new Core.Exceptions.InvalidOperationAppException("保存失败.");
            }
        }

        /// <summary>
        /// 客户补充
        /// </summary>
        public void FinanceCustomer()
        {
            // 获取数据
            var finance = GetData<OperationViewModel>("5ADC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 创建或修改
            financeAppService.EditOperation(finance);

            // 如果执行失败则抛出异常, 或用返回值表示结果.
            if (false)
            {
                throw new Core.Exceptions.InvalidOperationAppException("保存失败.");
            }
        }

        private T GetData<T>(string formId) where T : class, new()
        {
            return Data[formId.ToLower()].ToObject<T>();
        }
    }
}
