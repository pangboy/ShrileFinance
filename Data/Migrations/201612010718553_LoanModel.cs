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
                        OrganizationId = c.Guid(nullable: false),
                        CreditContractCode = c.String(maxLength: 60),
                        EffectiveDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        CreditLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EffectiveStatus = c.Byte(nullable: false),
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
            
            CreateTable(
                "dbo.LOAN_Loan",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CreditId = c.Guid(nullable: false),
                        Principle = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SpecialDate = c.DateTime(nullable: false),
                        MatureDate = c.DateTime(nullable: false),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FourCategoryAssetsClassification = c.Int(),
                        FiveCategoryAssetsClassification = c.Int(nullable: false),
                        ContractNumber = c.String(nullable: false, maxLength: 128),
                        Status = c.Int(nullable: false),
                        LoanBusinessTypes = c.String(maxLength: 1),
                        LoanForm = c.String(maxLength: 1),
                        LoanNature = c.String(maxLength: 1),
                        LoansTo = c.String(maxLength: 5),
                        LoanTypes = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LOAN_CreditContranct", t => t.CreditId, cascadeDelete: true)
                .Index(t => t.CreditId);
            
            CreateTable(
                "dbo.LOAN_PaymentHistory",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        LoanId = c.Guid(nullable: false),
                        ScheduledPaymentPrincipal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ScheduledPaymentInterest = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualPaymentPrincipal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualPaymentInterest = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DatePayment = c.DateTime(nullable: false),
                        PaymentTypes = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LOAN_Loan", t => t.LoanId)
                .Index(t => t.LoanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOAN_Loan", "CreditId", "dbo.LOAN_CreditContranct");
            DropForeignKey("dbo.LOAN_PaymentHistory", "LoanId", "dbo.LOAN_Loan");
            DropForeignKey("dbo.LOAN_GuarantyContract", "CreditId", "dbo.LOAN_CreditContranct");
            DropForeignKey("dbo.LOAN_Guarantor", "GuarantyContractId", "dbo.LOAN_GuarantyContract");
            DropIndex("dbo.LOAN_PaymentHistory", new[] { "LoanId" });
            DropIndex("dbo.LOAN_Loan", new[] { "CreditId" });
            DropIndex("dbo.LOAN_Guarantor", new[] { "GuarantyContractId" });
            DropIndex("dbo.LOAN_GuarantyContract", new[] { "CreditId" });
            DropTable("dbo.LOAN_PaymentHistory");
            DropTable("dbo.LOAN_Loan");
            DropTable("dbo.LOAN_Guarantor");
            DropTable("dbo.LOAN_GuarantyContract");
            DropTable("dbo.LOAN_CreditContranct");
        }
    }
}
