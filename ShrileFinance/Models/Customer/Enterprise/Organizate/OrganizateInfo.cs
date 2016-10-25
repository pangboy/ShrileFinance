using System.Collections.Generic;

namespace Models.Customer.Enterprise.Organizate
{
    /// <summary>
    /// 机构基本信息记录
    /// </summary>
    public class OrganizateInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 基础段 B
        /// </summary>
        public virtual BasePeriod Base { get; set; }

        /// <summary>
        /// 基本信息段 C
        /// </summary>
        public virtual BasicPropertiesPeriod BasicProperties { get; set; }

        /// <summary>
        /// 机构状态 D
        /// </summary>
        public virtual InstitutionsStatePeriod InstitutionsState { get; set; }

        /// <summary>
        /// 联络信息 E
        /// </summary>
        public virtual ContactInformationPeriod ContactInformation { get; set; }

        /// <summary>
        /// 高管以及主要联系人 F
        /// </summary>
        public ICollection<ExecutivesMajorParticipantPeriod> ExecutivesMajorParticipant { get; set; }

        /// <summary>
        /// 重要股东 G
        /// </summary>
        public ICollection<MajorShareholdersPeriod> MajorShareholders { get; set; }

        /// <summary>
        /// 主要关联企业 H
        /// </summary>
        public ICollection<MainAssociatedEnterprisePerid> MainAssociatedEnterprise { get; set; }

        /// <summary>
        /// 上级机构 I
        /// </summary>
        public virtual SuperInstitutionPeriod SuperInstitution { get; set; }
    }
}
