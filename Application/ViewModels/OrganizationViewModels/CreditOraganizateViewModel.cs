using System;

namespace Application.ViewModels.OrganizationViewModels
{
    public class CreditOraganizateViewModel
    {

        /// <summary>
        /// 客户号
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 管理行代码
        /// </summary>
        public string ManagementerCode { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string InstitutionChName { get; set; }

        /// <summary>
        /// 中征码
        /// </summary>
        public string LoanCardCode { get; set; }

        /// <summary>
        /// 注册登记地址
        /// </summary>
        public string RegisterAddress { get; set; }

        /// <summary>
        /// 成立时间
        /// </summary>
        public DateTime SetupDate { get; set; }

        /// <summary>
        /// 注册资本
        /// </summary>
        public decimal RegisterCapital { get; set; }
    }
}
