namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance;

    public class FinanceConfigration : EntityTypeConfiguration<Finance>
    {
        public FinanceConfigration()
        {
            // 主键
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

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
            /// 金融手续费
            /// </summary>
            Property(m => m.Poundage).HasPrecision(18, 2);

            /// <summary>
            /// 月供额度
            /// </summary>
            Property(m => m.Payment).HasPrecision(18, 2);

            // 信审报告
            HasOptional(m => m.CreditExamine).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            // 合同
            HasOptional(m => m.Contact).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            // 融资扩展
            HasOptional(m => m.FinanceExtension).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            ToTable("FANC_Finance");
        }
    }
}
