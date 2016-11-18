namespace Application
{
    using Core.Entities.Flow;
    using Newtonsoft.Json.Linq;
    using ViewModels.FinanceViewModels;

    public class FinanceScriptAppService
    {
        public FinanceScriptAppService()
        {
        }

        /// <summary>
        /// 融资申请
        /// </summary>
        public void FinanceApply()
        {
            // 获取数据
            var finance = GetData<FinanceApplyViewModel>("57DC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 创建或修改
            // Create(finance);
            // Modify(finance);

            // 如果执行失败则抛出异常, 或用返回值表示结果.
            if (false)
            {
                throw new Core.Exceptions.InvalidOperationAppException("保存失败.");
            }

            // 设置流程实例关联的业务标识
            Instance.RootKey = finance.Id;
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
