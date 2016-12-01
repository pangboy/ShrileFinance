namespace Data.ModelConfigurations.Loan
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class GuarantorConfiguration : EntityTypeConfiguration<Guarantor>
    {
        public GuarantorConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Name).IsRequired().HasMaxLength(80);

            Map<GuarantyOrganization>(t => t.Requires("Type").HasValue("GuarantyOrganization"));
            Map<GuarantyPerson>(t => t.Requires("Type").HasValue("GuarantyPerson"));

            ToTable("LOAN_Guarantor");
        }
    }
}
