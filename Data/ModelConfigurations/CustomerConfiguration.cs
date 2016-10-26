namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers;
    using Core.Entities.Customers.Enterprise.Organizate;

    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(m => m.BasicProperties.BusinessScope).HasMaxLength(400);
            Property(m => m.CustomerNumber).IsRequired().HasMaxLength(40);
            Property(m => m.CustomerType).IsRequired().HasMaxLength(1);
            Property(m => m.DataExtractionDate).IsRequired().HasMaxLength(8);
            Property(m => m.InstitutionCreditCode).HasMaxLength(18);
            Property(m => m.LoanCardCode).IsRequired().HasMaxLength(16);
            Property(m => m.ManagementerCode).IsRequired().HasMaxLength(20);
            Property(m => m.NewaccountlicenseNumber).HasMaxLength(20);
            Property(m => m.OrganizateCode).HasMaxLength(10);
            Property(m => m.RegistrationNumber).HasMaxLength(20);
            Property(m => m.RegistrationNumberType).HasMaxLength(2);
            Property(m => m.TaxpayerIdentifyIrsNumber).HasMaxLength(20);
            Property(m => m.TaxpayerIdentifyLandNumber).HasMaxLength(20);
        }
    }
}
