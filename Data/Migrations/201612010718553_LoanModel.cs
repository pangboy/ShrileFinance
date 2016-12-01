namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoanModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LOAN_CreditContranct",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        LoanCode = c.String(maxLength: 60),
                        EffectiveDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        CreditLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValidStatus = c.Byte(nullable: false),
                        IsGuarantee = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LOAN_GuarantyContract",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SigningDate = c.DateTime(),
                        GuaranteeForm = c.Byte(),
                        EffectiveState = c.Byte(),
                        Margin = c.Decimal(precision: 18, scale: 2),
                        MortgageNumber = c.String(maxLength: 2),
                        AssessmentValue = c.Decimal(precision: 18, scale: 2),
                        AssessmentDate = c.DateTime(),
                        AssessmentName = c.String(maxLength: 80),
                        AssessmentOrganizationCode = c.String(maxLength: 10),
                        CollateralType = c.Byte(),
                        RegistrateAuthorit = c.String(maxLength: 80),
                        RegistrateDate = c.DateTime(),
                        CollateralInstruction = c.String(maxLength: 400),
                        PledgeNumber = c.String(maxLength: 2),
                        CollateralValue = c.Decimal(precision: 18, scale: 2),
                        PledgeType = c.Byte(),
                        CreditId = c.Guid(),
                        Type = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LOAN_CreditContranct", t => t.CreditId, cascadeDelete: true)
                .Index(t => t.CreditId);
            
            CreateTable(
                "dbo.LOAN_Guarantor",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        CreditcardCode = c.String(maxLength: 16),
                        CertificateType = c.String(maxLength: 1),
                        CertificateNumber = c.String(maxLength: 18),
                        GuarantyContractId = c.Guid(),
                        Type = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LOAN_GuarantyContract", t => t.GuarantyContractId)
                .Index(t => t.GuarantyContractId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOAN_GuarantyContract", "CreditId", "dbo.LOAN_CreditContranct");
            DropForeignKey("dbo.LOAN_Guarantor", "GuarantyContractId", "dbo.LOAN_GuarantyContract");
            DropIndex("dbo.LOAN_Guarantor", new[] { "GuarantyContractId" });
            DropIndex("dbo.LOAN_GuarantyContract", new[] { "CreditId" });
            DropTable("dbo.LOAN_Guarantor");
            DropTable("dbo.LOAN_GuarantyContract");
            DropTable("dbo.LOAN_CreditContranct");
        }
    }
}
