namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FANC_Vehicle", "VehicleCondition", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FANC_Vehicle", "VehicleCondition");
        }
    }
}
