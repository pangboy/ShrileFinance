namespace Application.ViewModels.OrganizationViewModels
{
    using System.Collections.Generic;

    public class Organization
    {
        /// <summary>
        /// 机构基础
        /// </summary>
        public BaseViewModel Base { get; set; }

        /// <summary>
        /// 机构属性
        /// </summary>
        public PropertiesViewModel Property { get; set; }

        /// <summary>
        /// 机构状态
        /// </summary>
        public StateViewModel State { get; set; }

        /// <summary>
        /// 机构联络
        /// </summary>
        public ContactViewModel Contact { get; set; }

        /// <summary>
        /// 高级主管
        /// </summary>
        public IEnumerable<ManagerViewModel> Managers { get; set; }

        /// <summary>
        /// 重要股东
        /// </summary>
        public IEnumerable<StockholderViewModel> Shareholders { get; set; }

        /// <summary>
        /// 主要关联企业
        /// </summary>
        public IEnumerable<AssociatedEnterpriseViewModel> AssociatedEnterprises { get; set; }

        /// <summary>
        /// 上级机构
        /// </summary>
        public ParentViewModel Parent { get; set; }
    }
}
