namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewStockholderUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CUST_FamilyMember", name: "PersonStockholderId", newName: "StockholderId");
            RenameIndex(table: "dbo.CUST_FamilyMember", name: "IX_PersonStockholderId", newName: "IX_StockholderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CUST_FamilyMember", name: "IX_StockholderId", newName: "IX_PersonStockholderId");
            RenameColumn(table: "dbo.CUST_FamilyMember", name: "StockholderId", newName: "PersonStockholderId");
        }
    }
}
