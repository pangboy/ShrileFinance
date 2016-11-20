namespace Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DraftModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Draft",
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
            DropForeignKey("dbo.Draft", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Draft", new[] { "UserId" });
            DropTable("dbo.Draft");
        }
    }
}
