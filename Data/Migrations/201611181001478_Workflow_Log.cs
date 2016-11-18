namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Workflow_Log : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FLOW_Log", new[] { "InstanceId" });
            AlterColumn("dbo.FLOW_Log", "InstanceId", c => c.Guid());
            CreateIndex("dbo.FLOW_Log", "InstanceId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FLOW_Log", new[] { "InstanceId" });
            AlterColumn("dbo.FLOW_Log", "InstanceId", c => c.Guid(nullable: false));
            CreateIndex("dbo.FLOW_Log", "InstanceId");
        }
    }
}
