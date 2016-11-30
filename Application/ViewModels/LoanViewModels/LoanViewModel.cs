namespace Application.ViewModels.LoanViewModels
{
    using System;

    public class LoanViewModel
    {
        public enum StutusEnum : byte
        {
            生效 = 0,
            失效 = 1,
            未结清 = 2
        }

        public Guid? Id { get; set; }

        /// <summary>
        /// 合同编码
        /// </summary>
        public string LoanCode { get; set; }

        /// <summary>
        /// 授信合同生效日期
        /// </summary>
        public DateTime EffectiveDate { get; set; }

        /// <summary>
        /// 授信合同终止日期
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// 授信额度
        /// </summary>
        public decimal CreditLimit { get; set; }

        /// <summary>
        /// 授信余额
        /// </summary>
        public decimal CreditBalance { get; set; }

        /// <summary>
        /// 合同有效状态
        /// </summary>
        public int ValidStatus { get; set; }

        /// <summary>
        /// 是否有担保
        /// </summary>
        public bool IsGuarantee { get; set; }
    }
}
