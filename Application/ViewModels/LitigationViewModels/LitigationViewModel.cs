namespace Application.ViewModels.LitigationViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class LitigationViewModel
    {
        /// <summary>
        /// 借款人名称
        /// </summary>
        [Display(Name = "借款人名称"), MaxLength(80), Required]
        public string BorrowName { get; set; }

        /// <summary>
        /// 贷款卡编码
        /// </summary>
        [Display(Name = "贷款卡编码"), StringLength(16), Required]
        public string LoanCardCode { get; set; }

        /// <summary>
        /// 业务发生日期
        /// </summary>
        [Display(Name = "业务发生日期"), StringLength(8), Required]
        public string BusinessDate { get; set; }

        /// <summary>
        /// 被起诉流水号
        /// </summary>
        [Display(Name = "被起诉流水号"), MaxLength(60), Required]
        public string ChargedSerialNumber { get; set; }

        /// <summary>
        /// 起诉人姓名
        /// </summary>
        [Display(Name = "起诉人姓名"), MaxLength(80), Required]
        public string ProsecuteName { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [Display(Name = "币种"), StringLength(3), Required]
        public string Currency { get; set; }

        /// <summary>
        /// 判决执行金额
        /// </summary>
        [Display(Name = "判决执行金额"), StringLength(20), Required]
        public string Money { get; set; }

        /// <summary>
        /// 判决执行日期
        /// </summary>
        [Display(Name = "判决执行日期"), StringLength(8), Required]
        public string DateTime { get; set; }

        /// <summary>
        /// 执行结果
        /// </summary>
        [Display(Name = "执行结果"), StringLength(100), Required]
        public string Result { get; set; }

        /// <summary>
        /// 被起诉原因
        /// </summary>
        [Display(Name = "被起诉原因"), StringLength(300), Required]
        public string Reason { get; set; }
    }
}
