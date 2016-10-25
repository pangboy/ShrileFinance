namespace Data.ModelConfigurations
{
    using Core.Entities.Concern;
    using System.Data.Entity.ModelConfiguration;
    public class AppLotigationConfiguration: EntityTypeConfiguration<Litigation>
    {
        public AppLotigationConfiguration() : base()
        {
            Property(m => m.ChargedSerialNumber).IsRequired().HasMaxLength(60);
            Property(m => m.Currency).IsRequired().HasMaxLength(3);
            Property(m => m.DateTime).IsRequired().HasMaxLength(8);
            Property(m => m.Money).IsRequired().HasMaxLength(20);
            Property(m => m.ProsecuteName).IsRequired().HasMaxLength(80);
            Property(m => m.Reason).IsRequired().HasMaxLength(300);
            Property(m => m.Result).IsRequired().HasMaxLength(100);
        }
    }
}
