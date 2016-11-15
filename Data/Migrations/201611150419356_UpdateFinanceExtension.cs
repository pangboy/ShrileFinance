namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFinanceExtension : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FinanceExtension", newName: "FANC_FinanceExtension");
            DropPrimaryKey("dbo.FANC_FinanceExtension");
            AddColumn("dbo.FANC_Finance", "OnePayInterest", c => c.Decimal(precision: 18, scale: 2));
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
            AlterColumn("dbo.FANC_Finance", "IntentionPrincipal", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "OncePayMonths", c => c.Int());
            AlterColumn("dbo.FANC_Finance", "AdviceMoney", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "AdviceRatio", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "ApprovalMoney", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "ApprovalRatio", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "Payment", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "RepayDate", c => c.DateTime());
            AlterColumn("dbo.FANC_Finance", "RepayRentDate", c => c.DateTime());
            AlterColumn("dbo.FANC_Applicant", "TotalMonthlyIncome", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "OtherIncome", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "HomeMonthlyIncome", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "HomeMonthlyExpend", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "FamilyNumber", c => c.Int());
            AlterColumn("dbo.FANC_FinanceExtension", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.FINC_Vehicle", "RegisterDate", c => c.DateTime());
            AlterColumn("dbo.FINC_Vehicle", "RunningMiles", c => c.Int());
            AlterColumn("dbo.FINC_Vehicle", "FactoryDate", c => c.DateTime());
            AlterColumn("dbo.FINC_Vehicle", "BuyCarYears", c => c.DateTime());
            AddPrimaryKey("dbo.FANC_FinanceExtension", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FANC_FinanceExtension");
            AlterColumn("dbo.FINC_Vehicle", "BuyCarYears", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FINC_Vehicle", "FactoryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FINC_Vehicle", "RunningMiles", c => c.Int(nullable: false));
            AlterColumn("dbo.FINC_Vehicle", "RegisterDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FANC_FinanceExtension", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.FANC_Applicant", "FamilyNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.FANC_Applicant", "HomeMonthlyExpend", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "HomeMonthlyIncome", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "OtherIncome", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Applicant", "TotalMonthlyIncome", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "RepayRentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FANC_Finance", "RepayDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FANC_Finance", "Payment", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "ApprovalRatio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "ApprovalMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "AdviceRatio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "AdviceMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Finance", "OncePayMonths", c => c.Int(nullable: false));
            AlterColumn("dbo.FANC_Finance", "IntentionPrincipal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
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
            DropColumn("dbo.FANC_Finance", "OnePayInterest");
            AddPrimaryKey("dbo.FANC_FinanceExtension", "Id");
            RenameTable(name: "dbo.FANC_FinanceExtension", newName: "FinanceExtension");
        }
    }
}
