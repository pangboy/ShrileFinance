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

            Property(m => m.RepaymentDate).IsRequired();

            Property(m => m.FirstPaymentDate).IsRequired();

            Property(m => m.Margin).IsRequired();

            Property(m => m.PayMonthly).IsRequired();

            Property(m => m.OnePayInterest).IsRequired();

            Property(m => m.ActualAmount).IsRequired();

            Property(m => m.LoanPrincipal).IsRequired();

            Property(m => m.CreditAccountId).IsRequired();

            Property(m => m.CreditBankName).IsRequired().HasMaxLength(40);

            Property(m => m.CreditBankCard).IsRequired().HasMaxLength(40);

            Property(m => m.ContactJson).IsRequired().HasMaxLength(800);

            ToTable("FANC_FinanceExtension");
        }
    }
}
