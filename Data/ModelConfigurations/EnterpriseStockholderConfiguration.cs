namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    public class EnterpriseStockholderConfiguration : EntityTypeConfiguration<EnterpriseStockholder>
    {
        public EnterpriseStockholderConfiguration()
        {
            Property(m => m.RegistraterType).HasMaxLength(2);
            Property(m => m.RegistraterCode).HasMaxLength(20);
            Property(m => m.OrganizateCode).HasMaxLength(10);
            Property(m => m.InstitutionCreditCode).HasMaxLength(18);
        }
    }
}
