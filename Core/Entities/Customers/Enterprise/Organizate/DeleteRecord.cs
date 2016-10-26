namespace Core.Entities.Customers.Enterprise.Organizate
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 删除报文记录
    /// </summary>
    public class DeleteRecord
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 信息类别
        /// </summary>
        public string InformationCategories
        {
            get
            {
                return "B";
            }
        }

        /// <summary>
        /// 客户号
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 需删除的信息类别
        /// </summary>
        public string NendDeleteInformationCategories { get; set; }

        /// <summary>
        /// 关系人类型
        /// </summary>
        public string ParticipantType { get; set; }

        /// <summary>
        /// 信息更新日期
        /// </summary>
        public string InformationUpdateDate { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        public string ReservedField { get; set; }
    }
}
