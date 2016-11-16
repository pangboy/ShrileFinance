namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FANC_Finance", "ProduceId", "dbo.PROD_Produce");
            DropIndex("dbo.FANC_Finance", new[] { "ProduceId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.FANC_Finance", "ProduceId");
            AddForeignKey("dbo.FANC_Finance", "ProduceId", "dbo.PROD_Produce", "Id");
        }
    }
}
