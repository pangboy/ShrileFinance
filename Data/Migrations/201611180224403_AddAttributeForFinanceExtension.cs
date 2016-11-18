namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttributeForFinanceExtension : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FANC_Finance", "CreateBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.FANC_Finance", "CreateOf_Id", c => c.Guid());
            AddColumn("dbo.FANC_FinanceExtension", "CreditAccountName", c => c.String(maxLength: 20));
            AddColumn("dbo.FANC_FinanceExtension", "CustomerAccountName", c => c.String(maxLength: 40));
            AddColumn("dbo.FANC_FinanceExtension", "CustomerBankName", c => c.String(maxLength: 40));
            AddColumn("dbo.FANC_FinanceExtension", "CustomerBankCard", c => c.String(maxLength: 40));
            AddColumn("dbo.FANC_Vehicle", "Condition", c => c.Byte(nullable: false));
            AddColumn("dbo.FANC_Vehicle", "BusinessType", c => c.Byte(nullable: false));
            AlterColumn("dbo.FANC_FinanceExtension", "LoanPrincipal", c => c.String(maxLength: 20));
            CreateIndex("dbo.FANC_Finance", "CreateBy_Id");
            CreateIndex("dbo.FANC_Finance", "CreateOf_Id");
            AddForeignKey("dbo.FANC_Finance", "CreateBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FANC_Finance", "CreateOf_Id", "dbo.CRET_Partner", "Id");
            DropColumn("dbo.FANC_Finance", "RepayDate");
            DropColumn("dbo.FANC_FinanceExtension", "CreditAccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FANC_FinanceExtension", "CreditAccountId", c => c.String());
            AddColumn("dbo.FANC_Finance", "RepayDate", c => c.DateTime());
            DropForeignKey("dbo.FANC_Finance", "CreateOf_Id", "dbo.CRET_Partner");
            DropForeignKey("dbo.FANC_Finance", "CreateBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FANC_Finance", new[] { "CreateOf_Id" });
            DropIndex("dbo.FANC_Finance", new[] { "CreateBy_Id" });
            AlterColumn("dbo.FANC_FinanceExtension", "LoanPrincipal", c => c.String());
            DropColumn("dbo.FANC_Vehicle", "BusinessType");
            DropColumn("dbo.FANC_Vehicle", "Condition");
            DropColumn("dbo.FANC_FinanceExtension", "CustomerBankCard");
            DropColumn("dbo.FANC_FinanceExtension", "CustomerBankName");
            DropColumn("dbo.FANC_FinanceExtension", "CustomerAccountName");
            DropColumn("dbo.FANC_FinanceExtension", "CreditAccountName");
            DropColumn("dbo.FANC_Finance", "CreateOf_Id");
            DropColumn("dbo.FANC_Finance", "CreateBy_Id");
        }
    }
}
