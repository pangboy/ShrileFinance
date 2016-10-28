namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CUST_Organization",
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
                "dbo.CUST_AssociatedEnterprise",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        AssociatedType = c.String(nullable: false, maxLength: 2),
                        Name = c.String(nullable: false, maxLength: 80),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        OrganizateCode = c.String(maxLength: 10),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        OrganizationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_Organization", t => t.OrganizationId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.CUST_Manager",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 1),
                        Name = c.String(nullable: false, maxLength: 80),
                        CertificateType = c.String(nullable: false, maxLength: 2),
                        CertificateCode = c.String(nullable: false, maxLength: 20),
                        OrganizationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_Organization", t => t.OrganizationId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.CUST_FamilyMember",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Relationship = c.String(nullable: false, maxLength: 1),
                        Name = c.String(nullable: false, maxLength: 80),
                        CertificateType = c.String(nullable: false, maxLength: 2),
                        CertificateCode = c.String(nullable: false, maxLength: 20),
                        ManagerId = c.Guid(),
                        PersonStockholderId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_Manager", t => t.ManagerId)
                .ForeignKey("dbo.CUST_Stockholder", t => t.PersonStockholderId)
                .Index(t => t.ManagerId)
                .Index(t => t.PersonStockholderId);
            
            CreateTable(
                "dbo.CUST_Stockholder",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ShareholdersType = c.String(nullable: false, maxLength: 1),
                        ShareholdersName = c.String(nullable: false, maxLength: 80),
                        SharesProportion = c.Decimal(nullable: false, precision: 10, scale: 2),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        OrganizateCode = c.String(maxLength: 10),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        CertificateType = c.String(maxLength: 2),
                        CertificateCode = c.String(maxLength: 20),
                        OrganizationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_Organization", t => t.OrganizationId)
                .Index(t => t.OrganizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CUST_Stockholder", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_FamilyMember", "PersonStockholderId", "dbo.CUST_Stockholder");
            DropForeignKey("dbo.CUST_Manager", "OrganizationId", "dbo.CUST_Organization");
            DropForeignKey("dbo.CUST_FamilyMember", "ManagerId", "dbo.CUST_Manager");
            DropForeignKey("dbo.CUST_AssociatedEnterprise", "OrganizationId", "dbo.CUST_Organization");
            DropIndex("dbo.CUST_Stockholder", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_FamilyMember", new[] { "PersonStockholderId" });
            DropIndex("dbo.CUST_FamilyMember", new[] { "ManagerId" });
            DropIndex("dbo.CUST_Manager", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_AssociatedEnterprise", new[] { "OrganizationId" });
            DropTable("dbo.CUST_Stockholder");
            DropTable("dbo.CUST_FamilyMember");
            DropTable("dbo.CUST_Manager");
            DropTable("dbo.CUST_AssociatedEnterprise");
            DropTable("dbo.CUST_Organization");
        }
    }
}
