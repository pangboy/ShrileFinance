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
            Ignore(m => m.AdviceMoney);

            /// <summary>
            /// 建议融资比例
            /// </summary>
            Ignore(m => m.AdviceRatio);

            /// <summary>
            /// 审批融资金额
            /// </summary>
            Ignore(m => m.ApprovalMoney);

            /// <summary>
            /// 审批融资比例
            /// </summary>
            Ignore(m => m.ApprovalRatio);

            /// <summary>
            /// 金融手续费
            /// </summary>
            Ignore(m => m.Poundage);

            /// <summary>
            /// 月供额度
            /// </summary>
            Ignore(m => m.Payment);

            // 信审报告
            HasOptional(m => m.CreditExamine).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            // 合同
            //HasOptional(m => m.Contact).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();
            Ignore(m => m.Contact);
            Ignore(m => m.FinanceExtension);

            // 融资扩展
            //HasOptional(m => m.FinanceExtension).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            ToTable("FANC_Finance");
        }
    }
}
