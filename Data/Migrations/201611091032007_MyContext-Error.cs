namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyContextError : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PROD_FinancingItem");
            AlterColumn("dbo.PROD_FinancingItem", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.PROD_FinancingItem", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PROD_FinancingItem");
            AlterColumn("dbo.PROD_FinancingItem", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.PROD_FinancingItem", "Id");
        }
    }
}
