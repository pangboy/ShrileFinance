namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrganizationReleation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CUST_FinancialAffairs", "OrganizationId", "dbo.CUST_Organization");
            DropIndex("dbo.CUST_AssociatedEnterprise", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_FinancialAffairs", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_Manager", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_Stockholder", new[] { "OrganizationId" });
            AlterColumn("dbo.CUST_AssociatedEnterprise", "OrganizationId", c => c.Guid());
            AlterColumn("dbo.CUST_FinancialAffairs", "OrganizationId", c => c.Guid());
            AlterColumn("dbo.CUST_Manager", "OrganizationId", c => c.Guid());
            AlterColumn("dbo.CUST_Stockholder", "OrganizationId", c => c.Guid());
            CreateIndex("dbo.CUST_AssociatedEnterprise", "OrganizationId");
            CreateIndex("dbo.CUST_FinancialAffairs", "OrganizationId");
            CreateIndex("dbo.CUST_Manager", "OrganizationId");
            CreateIndex("dbo.CUST_Stockholder", "OrganizationId");
            AddForeignKey("dbo.CUST_FinancialAffairs", "OrganizationId", "dbo.CUST_Organization", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CUST_FinancialAffairs", "OrganizationId", "dbo.CUST_Organization");
            DropIndex("dbo.CUST_Stockholder", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_Manager", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_FinancialAffairs", new[] { "OrganizationId" });
            DropIndex("dbo.CUST_AssociatedEnterprise", new[] { "OrganizationId" });
            AlterColumn("dbo.CUST_Stockholder", "OrganizationId", c => c.Guid(nullable: false));
            AlterColumn("dbo.CUST_Manager", "OrganizationId", c => c.Guid(nullable: false));
            AlterColumn("dbo.CUST_FinancialAffairs", "OrganizationId", c => c.Guid(nullable: false));
            AlterColumn("dbo.CUST_AssociatedEnterprise", "OrganizationId", c => c.Guid(nullable: false));
            CreateIndex("dbo.CUST_Stockholder", "OrganizationId");
            CreateIndex("dbo.CUST_Manager", "OrganizationId");
            CreateIndex("dbo.CUST_FinancialAffairs", "OrganizationId");
            CreateIndex("dbo.CUST_AssociatedEnterprise", "OrganizationId");
            AddForeignKey("dbo.CUST_FinancialAffairs", "OrganizationId", "dbo.CUST_Organization", "Id");
        }
    }
}
