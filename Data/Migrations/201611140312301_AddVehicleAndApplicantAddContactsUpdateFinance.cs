namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleAndApplicantAddContactsUpdateFinance : DbMigration
    {
        public override void Up()
        {
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
                        MaritalStatus = c.String(maxLength: 50),
                        Mobile = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        LiveHouseAddress = c.String(nullable: false, maxLength: 50),
                        ContactAddress = c.String(maxLength: 50),
                        ContactAddressType = c.String(maxLength: 50),
                        RegisteredAddress = c.String(maxLength: 50),
                        OfficeName = c.String(maxLength: 50),
                        Department = c.String(maxLength: 50),
                        Position = c.String(maxLength: 50),
                        IndustryType = c.String(maxLength: 50),
                        OfficePhone = c.String(maxLength: 50),
                        OfficeAddress = c.String(maxLength: 50),
                        WifeName = c.String(maxLength: 50),
                        WifePhone = c.String(maxLength: 50),
                        WifeOfficePhone = c.String(maxLength: 50),
                        WifeOfficeAddress = c.String(maxLength: 50),
                        TotalMonthlyIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HomeMonthlyIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HomeMonthlyExpend = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Degree = c.String(nullable: false, maxLength: 50),
                        FamilyNumber = c.Int(nullable: false),
                        OwneHouseCount = c.Int(nullable: false),
                        OwneHouse = c.String(maxLength: 1000),
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
                "dbo.FinanceExtension",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .Index(t => t.FinanceId);
            
            CreateTable(
                "dbo.FINC_Vehicle",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        VehicleKey = c.String(nullable: false, maxLength: 20),
                        ManufacturerGuidePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RegisterCity = c.String(maxLength: 50),
                        SallerName = c.String(maxLength: 50),
                        PlateNo = c.String(maxLength: 50),
                        FrameNo = c.String(maxLength: 50),
                        EngineNo = c.String(maxLength: 50),
                        RegisterDate = c.DateTime(nullable: false),
                        RunningMiles = c.Int(nullable: false),
                        FactoryDate = c.DateTime(nullable: false),
                        BuyCarYears = c.DateTime(nullable: false),
                        Color = c.String(maxLength: 50),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .Index(t => t.FinanceId);
            
            AddColumn("dbo.FANC_Finance", "RepaymentScheme", c => c.Byte(nullable: false));
            AddColumn("dbo.FANC_Finance", "IntentionPrincipal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Finance", "OncePayMonths", c => c.Int(nullable: false));
            AddColumn("dbo.FANC_Finance", "AdviceMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Finance", "AdviceRatio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Finance", "ApprovalMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Finance", "ApprovalRatio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Finance", "Payment", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_Finance", "RepayDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.FANC_Finance", "RepayRentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FANC_Finance", "RepaymentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FANC_CreditExamine", "TrialPersonId", c => c.String(maxLength: 128));
            AlterColumn("dbo.FANC_CreditExamine", "ReviewPersonId", c => c.String(maxLength: 128));
            AlterColumn("dbo.FANC_CreditExamine", "ApprovePersonId", c => c.String(maxLength: 128));
            AlterColumn("dbo.FANC_CreditExamine", "FinalPersonId", c => c.String(maxLength: 128));
            CreateIndex("dbo.FANC_CreditExamine", "ApprovePersonId");
            CreateIndex("dbo.FANC_CreditExamine", "FinalPersonId");
            CreateIndex("dbo.FANC_CreditExamine", "ReviewPersonId");
            CreateIndex("dbo.FANC_CreditExamine", "TrialPersonId");
            AddForeignKey("dbo.FANC_CreditExamine", "ApprovePersonId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FANC_CreditExamine", "FinalPersonId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FANC_CreditExamine", "ReviewPersonId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FANC_CreditExamine", "TrialPersonId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FINC_Vehicle", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.FinanceExtension", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.FANC_CreditExamine", "TrialPersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_CreditExamine", "ReviewPersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_CreditExamine", "FinalPersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_CreditExamine", "ApprovePersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FANC_Contact", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.FANC_Applicant", "FinanceId", "dbo.FANC_Finance");
            DropIndex("dbo.FINC_Vehicle", new[] { "FinanceId" });
            DropIndex("dbo.FinanceExtension", new[] { "FinanceId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "TrialPersonId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "ReviewPersonId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "FinalPersonId" });
            DropIndex("dbo.FANC_CreditExamine", new[] { "ApprovePersonId" });
            DropIndex("dbo.FANC_Contact", new[] { "FinanceId" });
            DropIndex("dbo.FANC_Applicant", new[] { "FinanceId" });
            AlterColumn("dbo.FANC_CreditExamine", "FinalPersonId", c => c.Guid(nullable: false));
            AlterColumn("dbo.FANC_CreditExamine", "ApprovePersonId", c => c.Guid(nullable: false));
            AlterColumn("dbo.FANC_CreditExamine", "ReviewPersonId", c => c.Guid(nullable: false));
            AlterColumn("dbo.FANC_CreditExamine", "TrialPersonId", c => c.Guid(nullable: false));
            AlterColumn("dbo.FANC_Finance", "RepaymentDate", c => c.Int(nullable: false));
            DropColumn("dbo.FANC_Finance", "RepayRentDate");
            DropColumn("dbo.FANC_Finance", "RepayDate");
            DropColumn("dbo.FANC_Finance", "Payment");
            DropColumn("dbo.FANC_Finance", "ApprovalRatio");
            DropColumn("dbo.FANC_Finance", "ApprovalMoney");
            DropColumn("dbo.FANC_Finance", "AdviceRatio");
            DropColumn("dbo.FANC_Finance", "AdviceMoney");
            DropColumn("dbo.FANC_Finance", "OncePayMonths");
            DropColumn("dbo.FANC_Finance", "IntentionPrincipal");
            DropColumn("dbo.FANC_Finance", "RepaymentScheme");
            DropTable("dbo.FINC_Vehicle");
            DropTable("dbo.FinanceExtension");
            DropTable("dbo.FANC_Contact");
            DropTable("dbo.FANC_Applicant");
        }
    }
}
