namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateApplicantAndFinanceExtension : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FinanceExtension", newName: "FANC_FinanceExtension");
            RenameTable(name: "dbo.FINC_Vehicle", newName: "FANC_Vehicle");
            DropPrimaryKey("dbo.FANC_FinanceExtension");
            AddColumn("dbo.FANC_Finance", "OnePayInterest", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.FANC_Applicant", "OwnHouseCount", c => c.Int(nullable: false));
            AddColumn("dbo.FANC_Applicant", "OwnHouse", c => c.String(maxLength: 1000));
            AddColumn("dbo.FANC_FinanceExtension", "LoanPrincipal", c => c.String());
            AddColumn("dbo.FANC_FinanceExtension", "CreditAccountId", c => c.String());
            AddColumn("dbo.FANC_FinanceExtension", "CreditBankName", c => c.String(maxLength: 40));
            AddColumn("dbo.FANC_FinanceExtension", "CreditBankCard", c => c.String(maxLength: 40));
            AddColumn("dbo.FANC_FinanceExtension", "ContactJson", c => c.String(maxLength: 800));
            AlterColumn("dbo.FANC_Finance", "Principal", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "InterestRate", c => c.Double());
            AlterColumn("dbo.FANC_Finance", "Periods", c => c.Int());
            AlterColumn("dbo.FANC_Finance", "RepaymentInterval", c => c.Int());
            AlterColumn("dbo.FANC_Finance", "RepaymentDate", c => c.DateTime());
            AlterColumn("dbo.FANC_Finance", "Bail", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "Cost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "DateEffective", c => c.DateTime());
            AlterColumn("dbo.FANC_Finance", "IntentionPrincipal", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "OncePayMonths", c => c.Int());
            AlterColumn("dbo.FANC_Finance", "AdviceMoney", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "AdviceRatio", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "ApprovalMoney", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "ApprovalRatio", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "Payment", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "RepayDate", c => c.DateTime());
            AlterColumn("dbo.FANC_Finance", "RepayRentDate", c => c.DateTime());
            AlterColumn("dbo.FANC_Applicant", "LiveHouseAddress", c => c.String(maxLength: 50));
            AlterColumn("dbo.FANC_Applicant", "TotalMonthlyIncome", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "OtherIncome", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "HomeMonthlyIncome", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "HomeMonthlyExpend", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "Degree", c => c.String(maxLength: 50));
            AlterColumn("dbo.FANC_Applicant", "FamilyNumber", c => c.Int());
            AlterColumn("dbo.FANC_FinanceExtension", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.FANC_Vehicle", "RegisterDate", c => c.DateTime());
            AlterColumn("dbo.FANC_Vehicle", "RunningMiles", c => c.Int());
            AlterColumn("dbo.FANC_Vehicle", "FactoryDate", c => c.DateTime());
            AddPrimaryKey("dbo.FANC_FinanceExtension", "Id");
            DropColumn("dbo.FANC_Applicant", "OwneHouseCount");
            DropColumn("dbo.FANC_Applicant", "OwneHouse");
            DropColumn("dbo.FANC_Vehicle", "BuyCarYears");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FANC_Vehicle", "BuyCarYears", c => c.DateTime(nullable: false));
            AddColumn("dbo.FANC_Applicant", "OwneHouse", c => c.String(maxLength: 1000));
            AddColumn("dbo.FANC_Applicant", "OwneHouseCount", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.FANC_FinanceExtension");
            AlterColumn("dbo.FANC_Vehicle", "FactoryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FANC_Vehicle", "RunningMiles", c => c.Int(nullable: false));
            AlterColumn("dbo.FANC_Vehicle", "RegisterDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FANC_FinanceExtension", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.FANC_Applicant", "FamilyNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.FANC_Applicant", "Degree", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.FANC_Applicant", "HomeMonthlyExpend", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "HomeMonthlyIncome", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "OtherIncome", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "TotalMonthlyIncome", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "LiveHouseAddress", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.FANC_Finance", "RepayRentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FANC_Finance", "RepayDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FANC_Finance", "Payment", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "ApprovalRatio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "ApprovalMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "AdviceRatio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "AdviceMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "OncePayMonths", c => c.Int(nullable: false));
            AlterColumn("dbo.FANC_Finance", "IntentionPrincipal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "DateEffective", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FANC_Finance", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "Bail", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "RepaymentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FANC_Finance", "RepaymentInterval", c => c.Int(nullable: false));
            AlterColumn("dbo.FANC_Finance", "Periods", c => c.Int(nullable: false));
            AlterColumn("dbo.FANC_Finance", "InterestRate", c => c.Double(nullable: false));
            AlterColumn("dbo.FANC_Finance", "Principal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.FANC_FinanceExtension", "ContactJson");
            DropColumn("dbo.FANC_FinanceExtension", "CreditBankCard");
            DropColumn("dbo.FANC_FinanceExtension", "CreditBankName");
            DropColumn("dbo.FANC_FinanceExtension", "CreditAccountId");
            DropColumn("dbo.FANC_FinanceExtension", "LoanPrincipal");
            DropColumn("dbo.FANC_Applicant", "OwnHouse");
            DropColumn("dbo.FANC_Applicant", "OwnHouseCount");
            DropColumn("dbo.FANC_Finance", "OnePayInterest");
            AddPrimaryKey("dbo.FANC_FinanceExtension", "Id");
            RenameTable(name: "dbo.FANC_Vehicle", newName: "FINC_Vehicle");
            RenameTable(name: "dbo.FANC_FinanceExtension", newName: "FinanceExtension");
        }
    }
}
