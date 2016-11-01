namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstitutionIncomeExpenditureUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CUST_InstitutionLiabilities", "销售税金1", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CUST_InstitutionLiabilities", "销售税金1");
        }
    }
}
