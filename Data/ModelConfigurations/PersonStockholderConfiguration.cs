namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    public class PersonStockholderConfiguration : EntityTypeConfiguration<PersonStockholder>
    {
        public PersonStockholderConfiguration()
        {
            Property(m => m.CertificateType).HasMaxLength(2);
            Property(m => m.CertificateCode).HasMaxLength(20);

            HasMany(m => m.FamilyMembers).WithOptional().Map(m => m.MapKey("PersonStockholderId"));
        }
    }
}
