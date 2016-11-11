namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFinanceAndCredit : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PROD_FinancingItem");
            CreateTable(
                "dbo.FANC_Finance",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Principal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InterestRate = c.Double(nullable: false),
                        Periods = c.Int(nullable: false),
                        RepaymentInterval = c.Int(nullable: false),
                        RepaymentDate = c.Int(nullable: false),
                        Bail = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        State = c.Byte(nullable: false),
                        DateEffective = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Produce_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PROD_Produce", t => t.Produce_Id)
                .Index(t => t.Produce_Id);
            
            CreateTable(
                "dbo.FANC_CreditExamine",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SubmitDataChannel = c.String(maxLength: 200),
                        LicenseRegistration = c.String(maxLength: 20),
                        CustomerCategory = c.String(maxLength: 20),
                        DetailedIndustry = c.String(maxLength: 20),
                        CensusRegisterSeat = c.String(maxLength: 20),
                        LivingSituation = c.String(maxLength: 20),
                        WorkingCondition = c.String(maxLength: 20),
                        IncomeSourceBusiness = c.Int(),
                        IncomeSourceWage = c.Int(),
                        MonthlyIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountingBasis = c.String(maxLength: 20),
                        NetnuclearPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NuclearGroupPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinalLine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditCondition = c.String(maxLength: 10),
                        SpecialInstructions = c.String(maxLength: 200),
                        Margin = c.String(maxLength: 20),
                        IncreaseMarginReson = c.String(maxLength: 400),
                        AgeRange = c.String(maxLength: 20),
                        AgeRangeOther = c.String(maxLength: 20),
                        MarriageState = c.String(maxLength: 20),
                        Live = c.String(maxLength: 20),
                        RealEstate = c.String(maxLength: 20),
                        Work = c.String(maxLength: 20),
                        FamilyVisit = c.String(maxLength: 20),
                        CapitalUse = c.String(maxLength: 400),
                        CableInquiry = c.String(maxLength: 400),
                        Conclusion = c.String(maxLength: 400),
                        SurveyOpinion = c.String(maxLength: 20),
                        SurveyOpinionReson = c.String(maxLength: 400),
                        TrialPersonId = c.Guid(nullable: false),
                        ReviewPersonId = c.Guid(nullable: false),
                        ApprovePersonId = c.Guid(nullable: false),
                        FinalPersonId = c.Guid(nullable: false),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .Index(t => t.FinanceId);
            
            AlterColumn("dbo.PROD_FinancingItem", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.PROD_FinancingItem", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FANC_Finance", "Produce_Id", "dbo.PROD_Produce");
            DropForeignKey("dbo.FANC_CreditExamine", "FinanceId", "dbo.FANC_Finance");
            DropIndex("dbo.FANC_CreditExamine", new[] { "FinanceId" });
            DropIndex("dbo.FANC_Finance", new[] { "Produce_Id" });
            DropPrimaryKey("dbo.PROD_FinancingItem");
            AlterColumn("dbo.PROD_FinancingItem", "Id", c => c.Guid(nullable: false, identity: true));
            DropTable("dbo.FANC_CreditExamine");
            DropTable("dbo.FANC_Finance");
            AddPrimaryKey("dbo.PROD_FinancingItem", "Id");
        }
    }
}
