namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    public class OrganizationConfiguration : EntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // 机构
            Property(m => m.CustomerNumber).IsRequired().HasMaxLength(40);
            Property(m => m.ManagementerCode).IsRequired().HasMaxLength(20);
            Property(m => m.CustomerType).IsRequired().HasMaxLength(1);
            Property(m => m.RegistraterType).HasMaxLength(2);
            Property(m => m.RegistraterCode).HasMaxLength(20);
            Property(m => m.InstitutionCreditCode).HasMaxLength(18);
            Property(m => m.OrganizateCode).HasMaxLength(10);
            Property(m => m.TaxpayerIdentifyIrsNumber).HasMaxLength(20);
            Property(m => m.TaxpayerIdentifyLandNumber).HasMaxLength(20);
            Property(m => m.LoanCardCode).IsRequired().HasMaxLength(16);
            Property(m => m.CreatedDate).IsRequired();

            Ignore(m => m.HasParent);

            // 机构属性
            Property(m => m.Property.InstitutionChName).IsRequired().HasMaxLength(80);
            Property(m => m.Property.RegisterAddress).HasMaxLength(80);
            Property(m => m.Property.RegisterAdministrativeDivision).HasMaxLength(6);
            Property(m => m.Property.SetupDate);
            Property(m => m.Property.CertificateDueDate);
            Property(m => m.Property.BusinessScope).HasMaxLength(400);
            Property(m => m.Property.RegisterCapital).HasPrecision(10, 2);
            Property(m => m.Property.OrganizationCategory).HasMaxLength(1);
            Property(m => m.Property.OrganizationCategorySubdivision).HasMaxLength(2);
            Property(m => m.Property.EconomicSectorsClassification).HasMaxLength(5);
            Property(m => m.Property.EconomicType).HasMaxLength(2);

            // 机构状态
            Property(m => m.State.EnterpriseScale).HasMaxLength(1);
            Property(m => m.State.InstitutionsState).HasMaxLength(1);

            // 联络信息
            Property(m => m.Contact.OfficeAddress).HasMaxLength(80);
            Property(m => m.Contact.ContactPhone).HasMaxLength(35);
            Property(m => m.Contact.FinancialContactPhone).HasMaxLength(35);

            // 上级机构
            Property(m => m.Parent.SuperInstitutionsName).IsRequired().HasMaxLength(80);
            Property(m => m.Parent.RegistraterType).HasMaxLength(2);
            Property(m => m.Parent.RegistraterCode).HasMaxLength(20);
            Property(m => m.Parent.OrganizateCode).HasMaxLength(10);
            Property(m => m.Parent.InstitutionCreditCode).HasMaxLength(18);

            // 集合
            HasMany(m => m.Managers).WithRequired().Map(m => m.MapKey("OrganizationId"));
            HasMany(m => m.Shareholders).WithRequired().Map(m => m.MapKey("OrganizationId"));
            HasMany(m => m.AssociatedEnterprises).WithRequired().Map(m => m.MapKey("OrganizationId"));

            ToTable("CUST_Organization");
        }
    }
}
