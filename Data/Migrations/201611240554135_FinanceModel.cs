namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinanceModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FANC_Finance",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ProduceId = c.Guid(nullable: false),
                        Principal = c.Decimal(precision: 18, scale: 2),
                        RepaymentDate = c.Int(),
                        RepaymentScheme = c.Byte(nullable: false),
                        Bail = c.Decimal(precision: 18, scale: 2),
                        OnePayInterest = c.Decimal(precision: 18, scale: 2),
                        State = c.Byte(nullable: false),
                        DateEffective = c.DateTime(),
                        DateCreated = c.DateTime(nullable: false),
                        Financing = c.Decimal(precision: 18, scale: 2),
                        Poundage = c.Decimal(precision: 18, scale: 2),
                        OncePayMonths = c.Int(),
                        AdviceMoney = c.Decimal(precision: 18, scale: 2),
                        AdviceRatio = c.Decimal(precision: 18, scale: 2),
                        ApprovalMoney = c.Decimal(precision: 18, scale: 2),
                        ApprovalRatio = c.Decimal(precision: 18, scale: 2),
                        Payment = c.Decimal(precision: 18, scale: 2),
                        RepayRentDate = c.DateTime(),
                        CreateBy_Id = c.String(maxLength: 128),
                        CreateOf_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreateBy_Id)
                .ForeignKey("dbo.CRET_Partner", t => t.CreateOf_Id)
                .ForeignKey("dbo.PROD_Produce", t => t.ProduceId)
                .Index(t => t.ProduceId)
                .Index(t => t.CreateBy_Id)
                .Index(t => t.CreateOf_Id);
            
            CreateTable(
                "dbo.FANC_Applicant",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Sex = c.String(nullable: false, maxLength: 5),
                        IdentityType = c.String(maxLength: 50),
                        Identity = c.String(maxLength: 50),
                        Type = c.Byte(nullable: false),
                        RelationWithMaster = c.String(maxLength: 50),
                        MaritalStatus = c.String(maxLength: 10),
                        Mobile = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        LiveHouseAddress = c.String(maxLength: 200),
                        ContactAddress = c.String(maxLength: 200),
                        ContactAddressType = c.String(maxLength: 10),
                        RegisteredAddress = c.String(maxLength: 200),
                        OfficeName = c.String(maxLength: 200),
                        Department = c.String(maxLength: 50),
                        Position = c.String(maxLength: 50),
                        IndustryType = c.String(maxLength: 100),
                        OfficePhone = c.String(maxLength: 50),
                        OfficeAddress = c.String(maxLength: 200),
                        WifeName = c.String(maxLength: 50),
                        WifePhone = c.String(maxLength: 50),
                        WifeOfficeName = c.String(maxLength: 100),
                        WifeOfficeAddress = c.String(maxLength: 200),
                        TotalMonthlyIncome = c.Decimal(precision: 18, scale: 2),
                        OtherIncome = c.Decimal(precision: 18, scale: 2),
                        HomeMonthlyIncome = c.Decimal(precision: 18, scale: 2),
                        HomeMonthlyExpend = c.Decimal(precision: 18, scale: 2),
                        Degree = c.String(maxLength: 50),
                        FamilyNumber = c.Int(),
                        OwnHouseCount = c.Int(nullable: false),
                        OwnHouse = c.String(maxLength: 1000),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .Index(t => t.FinanceId);
            
            CreateTable(
                "dbo.FANC_Contact",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Number = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        Path = c.String(maxLength: 200),
                        Date = c.DateTime(nullable: false),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .Index(t => t.FinanceId);
            
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
                        Live = c.String(maxLength: 20),
                        RealEstate = c.String(maxLength: 20),
                        Work = c.String(maxLength: 20),
                        FamilyVisit = c.String(maxLength: 20),
                        CapitalUse = c.String(maxLength: 400),
                        CableInquiry = c.String(maxLength: 400),
                        Conclusion = c.String(maxLength: 400),
                        SurveyOpinion = c.String(maxLength: 20),
                        SurveyOpinionReson = c.String(maxLength: 400),
                        ApprovePersonId = c.String(maxLength: 128),
                        FinalPersonId = c.String(maxLength: 128),
                        ReviewPersonId = c.String(maxLength: 128),
                        TrialPersonId = c.String(maxLength: 128),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApprovePersonId)
                .ForeignKey("dbo.AspNetUsers", t => t.FinalPersonId)
                .ForeignKey("dbo.AspNetUsers", t => t.ReviewPersonId)
                .ForeignKey("dbo.AspNetUsers", t => t.TrialPersonId)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .Index(t => t.ApprovePersonId)
                .Index(t => t.FinalPersonId)
                .Index(t => t.ReviewPersonId)
                .Index(t => t.TrialPersonId)
                .Index(t => t.FinanceId);
            
            CreateTable(
                "dbo.FANC_FinanceExtension",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        LoanPrincipal = c.String(maxLength: 20),
                        CreditAccountName = c.String(maxLength: 20),
                        CreditBankName = c.String(maxLength: 40),
                        CreditBankCard = c.String(maxLength: 40),
                        ContactJson = c.String(maxLength: 800),
                        CustomerAccountName = c.String(maxLength: 40),
                        CustomerBankName = c.String(maxLength: 40),
                        CustomerBankCard = c.String(maxLength: 40),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .Index(t => t.FinanceId);
            
            CreateTable(
                "dbo.FANC_FinanceProduce",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsFinancing = c.Boolean(nullable: false),
                        IsEdit = c.Boolean(nullable: false),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .Index(t => t.FinanceId);
            
            CreateTable(
                "dbo.FANC_Vehicle",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MakeCode = c.String(nullable: false, maxLength: 50),
                        VehicleCondition = c.Int(nullable: false),
                        FamilyCode = c.String(nullable: false, maxLength: 50),
                        VehicleKey = c.String(nullable: false, maxLength: 20),
                        ManufacturerGuidePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RegisterCity = c.String(maxLength: 50),
                        SallerName = c.String(maxLength: 50),
                        PlateNo = c.String(maxLength: 50),
                        FrameNo = c.String(maxLength: 50),
                        EngineNo = c.String(maxLength: 50),
                        RegisterDate = c.String(),
                        RunningMiles = c.Int(),
                        FactoryDate = c.String(),
                        BuyCarYears = c.Int(),
                        Color = c.String(maxLength: 50),
                        Condition = c.Byte(nullable: false),
                        BusinessType = c.Byte(nullable: false),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .Index(t => t.FinanceId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FANC_Vehicle", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.FANC_Finance", "ProduceId", "dbo.PROD_Produce");
            DropForeignKey("dbo.FANC_FinanceProduce", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.FANC_FinanceExtension", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.FANC_CreditExamine", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.FANC_CreditExamine", "TrialPersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_CreditExamine", "ReviewPersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_CreditExamine", "FinalPersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_CreditExamine", "ApprovePersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_Finance", "CreateOf_Id", "dbo.CRET_Partner");
            DropForeignKey("dbo.FANC_Finance", "CreateBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_Contact", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.FANC_Applicant", "FinanceId", "dbo.FANC_Finance");
            DropIndex("dbo.FANC_Vehicle", new[] { "FinanceId" });
            DropIndex("dbo.FANC_FinanceProduce", new[] { "FinanceId" });
            DropIndex("dbo.FANC_FinanceExtension", new[] { "FinanceId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "FinanceId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "TrialPersonId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "ReviewPersonId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "FinalPersonId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "ApprovePersonId" });
            DropIndex("dbo.FANC_Contact", new[] { "FinanceId" });
            DropIndex("dbo.FANC_Applicant", new[] { "FinanceId" });
            DropIndex("dbo.FANC_Finance", new[] { "CreateOf_Id" });
            DropIndex("dbo.FANC_Finance", new[] { "CreateBy_Id" });
            DropIndex("dbo.FANC_Finance", new[] { "ProduceId" });
            DropTable("dbo.FANC_Vehicle");
            DropTable("dbo.FANC_FinanceProduce");
            DropTable("dbo.FANC_FinanceExtension");
            DropTable("dbo.FANC_CreditExamine");
            DropTable("dbo.FANC_Contact");
            DropTable("dbo.FANC_Applicant");
            DropTable("dbo.FANC_Finance");
        }
    }
}
