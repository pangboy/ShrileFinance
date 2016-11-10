namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance;

    /// <summary>
    /// 融资审核
    /// </summary>
    public class FinanceAuidtConfiguration : EntityTypeConfiguration<FinanceAudit>
    {
        public FinanceAuidtConfiguration()
        {
            // 主键
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            /// <summary>
            /// 厂商指导价
            /// </summary>
            Property(m => m.ManufacturerGuidePrice).HasPrecision(18, 2);

            /// <summary>
            /// 评估现市值
            /// </summary>
            Property(m => m.ApprovalValue).HasPrecision(18, 2);

            /// <summary>
            /// 建议融资金额
            /// </summary>
            Property(m => m.AdviceMoney).HasPrecision(18, 2);

            /// <summary>
            /// 建议融资比例
            /// </summary>
            Property(m => m.AdviceRatio).HasPrecision(18, 2);

            /// <summary>
            /// 审批融资金额
            /// </summary>
            Property(m => m.ApprovalMoney).HasPrecision(18, 2);

            /// <summary>
            /// 审批融资比例
            /// </summary>
            Property(m => m.ApprovalRatio).HasPrecision(18, 2);

            /// <summary>
            /// 月供额度
            /// </summary>
            Property(m => m.Payment).HasPrecision(18, 2);

            /// <summary>
            /// 手续费
            /// </summary>
            Property(m => m.Poundage).HasPrecision(18, 2);
        }
    }
}
