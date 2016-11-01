namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFinanceAffairs : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CUST_FinancialAffairs", new[] { "OrganizationId" });
            AlterColumn("dbo.CUST_FinancialAffairs", "OrganizationId", c => c.Guid(nullable: false));
            CreateIndex("dbo.CUST_FinancialAffairs", "OrganizationId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CUST_FinancialAffairs", new[] { "OrganizationId" });
            AlterColumn("dbo.CUST_FinancialAffairs", "OrganizationId", c => c.Guid());
            CreateIndex("dbo.CUST_FinancialAffairs", "OrganizationId");
        }
    }
}
