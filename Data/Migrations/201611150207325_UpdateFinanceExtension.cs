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
            AddColumn("dbo.FANC_Finance", "OnePayInterest", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FANC_FinanceExtension", "LoanPrincipal", c => c.String(nullable: false));
            AddColumn("dbo.FANC_FinanceExtension", "CreditAccountId", c => c.String(nullable: false));
            AddColumn("dbo.FANC_FinanceExtension", "CreditBankName", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.FANC_FinanceExtension", "CreditBankCard", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.FANC_FinanceExtension", "ContactJson", c => c.String(nullable: false, maxLength: 800));
            AlterColumn("dbo.FANC_FinanceExtension", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.FANC_FinanceExtension", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FANC_FinanceExtension");
            AlterColumn("dbo.FANC_FinanceExtension", "Id", c => c.Guid(nullable: false));
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
