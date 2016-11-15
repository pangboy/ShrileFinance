namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance;

    public class FinanceExtensionConfiguration : EntityTypeConfiguration<FinanceExtension>
    {
        public FinanceExtensionConfiguration()
        {
            // 主键
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.LoanPrincipal).IsRequired();

            Property(m => m.CreditAccountId).IsRequired();

            Property(m => m.CreditBankName).IsRequired().HasMaxLength(40);

            Property(m => m.CreditBankCard).IsRequired().HasMaxLength(40);

            Property(m => m.ContactJson).IsRequired().HasMaxLength(800);

            ToTable("FANC_FinanceExtension");
        }
    }
}
