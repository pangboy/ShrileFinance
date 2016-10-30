namespace Application.ViewModels.OrganizationViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class LitigationViewModel
    {
        /// <summary>
        /// 被起诉流水号
        /// </summary>
        [Required]
        public string ChargedSerialNumber { get; set; }

        /// <summary>
        /// 起诉人姓名
        /// </summary>
        [Required]
        public string ProsecuteName { get; set; }

        /// <summary>
        /// 判决执行金额
        /// </summary>
        [Required]
        public decimal Money { get; set; }

        /// <summary>
        /// 判决执行日期
        /// </summary>
        [Required]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 执行结果
        /// </summary>
        [Required]
        public string Result { get; set; }

        /// <summary>
        /// 被起诉原因
        /// </summary>
        [Required]
        public string Reason { get; set; }
    }
}
