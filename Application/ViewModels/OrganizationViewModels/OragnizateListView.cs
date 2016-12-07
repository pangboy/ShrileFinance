namespace Application.ViewModels.OrganizationViewModels
{
    using System;

    public class OragnizateListItemViewModel
    {
        /// <summary>
        /// GuidId
        /// </summary>
        public Guid? Id { get; set; }

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
        /// 机构信用代码
        /// </summary>
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedDate { get; set; }
    }
}
