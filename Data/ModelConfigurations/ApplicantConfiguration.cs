namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance;

    /// <summary>
    /// 联系人
    /// </summary>
    public class ApplicantConfiguration : EntityTypeConfiguration<Applicant>
    {
        public ApplicantConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Name).IsRequired().HasMaxLength(50);
            Property(m => m.Sex).IsRequired().HasMaxLength(5);
            Property(m => m.IdentityType).HasMaxLength(50);
            Property(m => m.Identity).HasMaxLength(50);
            Property(m => m.Type).IsRequired();
            Property(m => m.RelationWithMaster).HasMaxLength(50);
            Property(m => m.MaritalStatus).HasMaxLength(50);
            Property(m => m.Mobile).IsRequired().HasMaxLength(50);
            Property(m => m.Phone).HasMaxLength(50);
            Property(m => m.LiveHouseAddress).HasMaxLength(50);
            Property(m => m.ContactAddress).HasMaxLength(50);
            Property(m => m.ContactAddressType).HasMaxLength(50);
            Property(m => m.RegisteredAddress).HasMaxLength(50);
            Property(m => m.OfficeName).HasMaxLength(50);
            Property(m => m.Department).HasMaxLength(50);
            Property(m => m.Position).HasMaxLength(50);
            Property(m => m.IndustryType).HasMaxLength(50);
            Property(m => m.OfficePhone).HasMaxLength(50);
            Property(m => m.OfficeAddress).HasMaxLength(50);
            Property(m => m.WifeName).HasMaxLength(50);
            Property(m => m.WifePhone).HasMaxLength(50);
            Property(m => m.WifeOfficePhone).HasMaxLength(50);
            Property(m => m.WifeOfficeAddress).HasMaxLength(50);
            Property(m => m.TotalMonthlyIncome);
            Property(m => m.OtherIncome);
            Property(m => m.HomeMonthlyIncome);
            Property(m => m.HomeMonthlyExpend);
            Property(m => m.Degree).HasMaxLength(50);
            Property(m => m.FamilyNumber);
            Property(m => m.OwnHouse).HasMaxLength(1000);
            Property(m => m.OwnHouseCount);

            ToTable("FANC_Applicant");
        }
    }
}
