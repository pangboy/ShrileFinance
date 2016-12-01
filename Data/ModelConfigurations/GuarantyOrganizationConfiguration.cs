namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class GuarantyOrganizationConfiguration:EntityTypeConfiguration<GuarantyOrganization>
    {
        public GuarantyOrganizationConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Name).IsOptional().HasMaxLength(80);
            Property(m => m.CreditcardCode).IsRequired().HasMaxLength(16);
        }
    }
}
