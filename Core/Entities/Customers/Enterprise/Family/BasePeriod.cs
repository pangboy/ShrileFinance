namespace Models.Customer.Enterprise.Family
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 基础段（家族）
    /// </summary>
    public class BasePeriod : DeleteRecord
    {
        /// <summary>
        /// 主要关系人姓名
        /// </summary>
        public string MainParticipantName { get; set; }

        /// <summary>
        /// 家族成员姓名
        /// </summary>
        public string FamilyMembersName { get; set; }
    }
}
