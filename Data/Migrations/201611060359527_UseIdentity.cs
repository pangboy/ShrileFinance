namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UseIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Power", c => c.Int());
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetRoles", "Power");
        }
    }
}
