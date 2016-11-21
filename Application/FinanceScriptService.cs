namespace Application
{
    using System.Linq;
    using Core.Entities.Flow;
    using Core.Interfaces.Repositories;
    using Newtonsoft.Json.Linq;
    using ViewModels.FinanceViewModels;

    public class FinanceScriptAppService
    {
        private readonly FinanceAppService financeService;

        public FinanceScriptAppService(FinanceAppService financeService)
        {
            this.financeService = financeService;
        }

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
                financeService.Modify(finance);
            }
            else
            {
                financeService.Create(finance);

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
        }

        /// <summary>
        /// 融资复审
        /// </summary>
        public void FinanceReaudit()
        {
        }

        public Instance Instance { get; set; }

        public JObject Data { get; set; }

        private T GetData<T>(string formId) where T : class, new()
        {
            return Data[formId.ToLower()].ToObject<T>();
        }
    }
}
