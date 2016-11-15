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

            Property(m => m.LoanPrincipal);

            Property(m => m.CreditAccountId);

            Property(m => m.CreditBankName).HasMaxLength(40);

            Property(m => m.CreditBankCard).HasMaxLength(40);

            Property(m => m.ContactJson).HasMaxLength(800);

            ToTable("FANC_FinanceExtension");
        }
    }
}
