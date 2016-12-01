namespace Data.ModelConfigurations.Loan
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class GuarantyOrganizationConfiguration:EntityTypeConfiguration<GuarantorOrganization>
    {
        public GuarantyOrganizationConfiguration()
        {
            //HasKey(m => m.Id);
            //Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Property(m => m.Name).IsRequired().HasMaxLength(80);
            Property(m => m.CreditcardCode).IsRequired().HasMaxLength(16);
        }
    }
}
