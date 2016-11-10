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


            // 信审报告
            HasOptional(m => m.CreditExamine).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            // 融资审核
            HasOptional(m => m.FinanceAudit).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            ToTable("FANC_Finance");
        }
    }
}
