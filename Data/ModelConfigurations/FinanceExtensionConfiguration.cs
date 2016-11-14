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

            ToTable("FANC_FinanceExtension");
        }
    }
}
