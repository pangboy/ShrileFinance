namespace Application.ViewModels.Loan.CreditViewModel
{
    using System;

    /// <summary>
    /// 担保人
    /// </summary>
    public class GuarantorViewModel : IEntityViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string Name { get; set; }
    }
}
