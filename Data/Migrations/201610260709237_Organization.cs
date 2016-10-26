namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CustomerNumber = c.String(nullable: false, maxLength: 40),
                        ManagementerCode = c.String(nullable: false, maxLength: 20),
                        CustomerType = c.String(nullable: false, maxLength: 1),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        OrganizateCode = c.String(maxLength: 10),
                        TaxpayerIdentifyIrsNumber = c.String(maxLength: 20),
                        TaxpayerIdentifyLandNumber = c.String(maxLength: 20),
                        LoanCardCode = c.String(nullable: false, maxLength: 16),
                        CreatedDate = c.DateTime(nullable: false),
                        Property_InstitutionChName = c.String(nullable: false, maxLength: 80),
                        Property_RegisterAddress = c.String(maxLength: 80),
                        Property_RegisterAdministrativeDivision = c.String(maxLength: 6),
                        Property_SetupDate = c.DateTime(nullable: false),
                        Property_CertificateDueDate = c.DateTime(nullable: false),
                        Property_BusinessScope = c.String(maxLength: 400),
                        Property_RegisterCapital = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Property_OrganizationCategory = c.String(maxLength: 1),
                        Property_OrganizationCategorySubdivision = c.String(maxLength: 2),
                        Property_EconomicSectorsClassification = c.String(maxLength: 5),
                        Property_EconomicType = c.String(maxLength: 2),
                        State_EnterpriseScale = c.String(maxLength: 1),
                        State_InstitutionsState = c.String(maxLength: 1),
                        Contact_OfficeAddress = c.String(maxLength: 80),
                        Contact_ContactPhone = c.String(maxLength: 35),
                        Contact_FinancialContactPhone = c.String(maxLength: 35),
                        Parent_SuperInstitutionsName = c.String(nullable: false, maxLength: 80),
                        Parent_RegistraterType = c.String(maxLength: 2),
                        Parent_RegistraterCode = c.String(maxLength: 20),
                        Parent_OrganizateCode = c.String(maxLength: 10),
                        Parent_InstitutionCreditCode = c.String(maxLength: 18),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssociatedEnterprise",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AssociatedType = c.String(),
                        Name = c.String(),
                        RegistraterType = c.String(),
                        RegistraterCode = c.String(),
                        OrganizateCode = c.String(),
                        InstitutionCreditCode = c.String(),
                        Organization_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "dbo.Manager",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(),
                        Name = c.String(),
                        CertificateType = c.String(),
                        CertificateCode = c.String(),
                        Organization_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "dbo.FamilyMember",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Relationship = c.String(),
                        Name = c.String(),
                        CertificateType = c.String(),
                        CertificateCode = c.String(),
                        Manager_Id = c.Guid(),
                        PersonStockholder_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manager", t => t.Manager_Id)
                .ForeignKey("dbo.Stockholder", t => t.PersonStockholder_Id)
                .Index(t => t.Manager_Id)
                .Index(t => t.PersonStockholder_Id);
            
            CreateTable(
                "dbo.Stockholder",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ShareholdersName = c.String(),
                        SharesProportion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RegistraterType = c.String(),
                        RegistraterCode = c.String(),
                        OrganizateCode = c.String(),
                        InstitutionCreditCode = c.String(),
                        CertificateType = c.String(),
                        CertificateCode = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Organization_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .Index(t => t.Organization_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stockholder", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.FamilyMember", "PersonStockholder_Id", "dbo.Stockholder");
            DropForeignKey("dbo.Manager", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.FamilyMember", "Manager_Id", "dbo.Manager");
            DropForeignKey("dbo.AssociatedEnterprise", "Organization_Id", "dbo.Organization");
            DropIndex("dbo.Stockholder", new[] { "Organization_Id" });
            DropIndex("dbo.FamilyMember", new[] { "PersonStockholder_Id" });
            DropIndex("dbo.FamilyMember", new[] { "Manager_Id" });
            DropIndex("dbo.Manager", new[] { "Organization_Id" });
            DropIndex("dbo.AssociatedEnterprise", new[] { "Organization_Id" });
            DropTable("dbo.Stockholder");
            DropTable("dbo.FamilyMember");
            DropTable("dbo.Manager");
            DropTable("dbo.AssociatedEnterprise");
            DropTable("dbo.Organization");
        }
    }
}
