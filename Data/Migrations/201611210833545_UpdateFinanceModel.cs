namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFinanceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FANC_Finance", "Financing", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.FANC_Finance", "Poundage", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Vehicle", "RegisterDate", c => c.String());
            AlterColumn("dbo.FANC_Vehicle", "FactoryDate", c => c.String());
            DropColumn("dbo.FANC_Finance", "Cost");
            DropColumn("dbo.FANC_Finance", "IntentionPrincipal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FANC_Finance", "IntentionPrincipal", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.FANC_Finance", "Cost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.FANC_Vehicle", "FactoryDate", c => c.DateTime());
            AlterColumn("dbo.FANC_Vehicle", "RegisterDate", c => c.DateTime());
            DropColumn("dbo.FANC_Finance", "Poundage");
            DropColumn("dbo.FANC_Finance", "Financing");
        }
    }
}
