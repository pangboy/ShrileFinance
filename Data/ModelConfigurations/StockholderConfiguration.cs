namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    public class StockholderConfiguration : EntityTypeConfiguration<Stockholder>
    {
        public StockholderConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.ShareholdersType).IsRequired().HasMaxLength(1);
            Map<PersonStockholder>(t => t.Requires("ShareholdersType").HasValue("1"));
            Map<EnterpriseStockholder>(t => t.Requires("ShareholdersType").HasValue("2"));

            Property(m => m.ShareholdersName).IsRequired().HasMaxLength(80);
            Property(m => m.SharesProportion).IsRequired().HasPrecision(10, 2);

            ToTable("CUST_Stockholder");
        }
    }
}
