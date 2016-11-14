namespace Application.ViewModels.FinanceViewModels
{
    using System;

   public class ContractViewModel
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 合同日期
        /// </summary>
        public DateTime Date { get; set; }
    }
}
