namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DraftModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SYS_Draft",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        PageLink = c.String(maxLength: 400),
                        PageData = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SYS_Draft", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.SYS_Draft", new[] { "UserId" });
            DropTable("dbo.SYS_Draft");
        }
    }
}
