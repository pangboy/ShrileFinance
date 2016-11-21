namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVehicleDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FANC_Vehicle", "RegisterDate", c => c.String());
            AlterColumn("dbo.FANC_Vehicle", "FactoryDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FANC_Vehicle", "FactoryDate", c => c.DateTime());
            AlterColumn("dbo.FANC_Vehicle", "RegisterDate", c => c.DateTime());
        }
    }
}
