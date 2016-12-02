namespace Application.ViewModels.Loan.LoanViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Core.Entities.Loan;

    public class LoanViewModel : IEntityViewModel
    {
        public Guid? Id { get; private set; }

        [Required]
        public Guid CreditContractId { get; set; }

        /// <summary>
        /// 借据金额
        /// </summary>
        [Required]
        public decimal Principle { get; private set; }

        /// <summary>
        /// 借据余额
        /// </summary>
        public decimal Balance { get; private set; }

        /// <summary>
        /// 放款日期
        /// </summary>
        [Required]
        public DateTime SpecialDate { get; private set; }

        /// <summary>
        /// 到期日期
        /// </summary>
        [Required]
        public DateTime MatureDate { get; private set; }

        /// <summary>
        /// 四级分类
        /// </summary>
        [Required]
        public FourCategoryAssetsClassificationEnum? FourCategoryAssetsClassification { get; private set; }

        /// <summary>
        /// 五级分类
        /// </summary>
        [Required]
        public FiveCategoryAssetsClassificationEnum FiveCategoryAssetsClassification { get; private set; }

        /// <summary>
        /// 借据编号
        /// </summary>
        [Required]
        public string ContractNumber { get; private set; }

        /// <summary>
        /// 借据状态
        /// </summary>
        public LoanStatusEnum Status { get; private set; }

        /// <summary>
        /// 贷款业务种类
        /// </summary>
        [Required]
        public string LoanBusinessTypes { get; private set; }

        /// <summary>
        /// 贷款形式
        /// </summary>
        [Required]
        public string LoanForm { get; private set; }

        /// <summary>
        /// 贷款性质
        /// </summary>
        [Required]
        public string LoanNature { get; private set; }

        /// <summary>
        /// 贷款投向
        /// </summary>
        [Required]
        public string LoansTo { get; private set; }

        /// <summary>
        /// 贷款种类
        /// </summary>
        [Required]
        public string LoanTypes { get; private set; }

        /// <summary>
        /// 还款记录
        /// </summary>
        public IEnumerable<PaymentHistoryViewModel> Payments { get; private set; }
    }
}
