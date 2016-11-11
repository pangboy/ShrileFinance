namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance;

    /// <summary>
    /// 合同
    /// </summary>
    public class ContactConfiguration:EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            // 主键
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Number).HasMaxLength(100);

            Property(m => m.Date);
        }
    }
}
