namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttributeForFinanceExtension : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FANC_FinanceExtension", "CreditAccountName", c => c.String(maxLength: 20));
            AddColumn("dbo.FANC_FinanceExtension", "CustomerAccountName", c => c.String(maxLength: 40));
            AddColumn("dbo.FANC_FinanceExtension", "CustomerBankName", c => c.String(maxLength: 40));
            AddColumn("dbo.FANC_FinanceExtension", "CustomerBankCard", c => c.String(maxLength: 40));
            AlterColumn("dbo.FANC_FinanceExtension", "LoanPrincipal", c => c.String(maxLength: 20));
            DropColumn("dbo.FANC_FinanceExtension", "CreditAccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FANC_FinanceExtension", "CreditAccountId", c => c.String());
            AlterColumn("dbo.FANC_FinanceExtension", "LoanPrincipal", c => c.String());
            DropColumn("dbo.FANC_FinanceExtension", "CustomerBankCard");
            DropColumn("dbo.FANC_FinanceExtension", "CustomerBankName");
            DropColumn("dbo.FANC_FinanceExtension", "CustomerAccountName");
            DropColumn("dbo.FANC_FinanceExtension", "CreditAccountName");
        }
    }
}
