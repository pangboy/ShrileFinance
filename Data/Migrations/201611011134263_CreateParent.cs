namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateParent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CUST_Parent",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SuperInstitutionsName = c.String(nullable: false, maxLength: 80),
                        RegistraterType = c.String(maxLength: 2),
                        RegistraterCode = c.String(maxLength: 20),
                        OrganizateCode = c.String(maxLength: 10),
                        InstitutionCreditCode = c.String(maxLength: 18),
                        OrganizationId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CUST_Organization", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            DropColumn("dbo.CUST_Organization", "Parent_SuperInstitutionsName");
            DropColumn("dbo.CUST_Organization", "Parent_RegistraterType");
            DropColumn("dbo.CUST_Organization", "Parent_RegistraterCode");
            DropColumn("dbo.CUST_Organization", "Parent_OrganizateCode");
            DropColumn("dbo.CUST_Organization", "Parent_InstitutionCreditCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CUST_Organization", "Parent_InstitutionCreditCode", c => c.String(maxLength: 18));
            AddColumn("dbo.CUST_Organization", "Parent_OrganizateCode", c => c.String(maxLength: 10));
            AddColumn("dbo.CUST_Organization", "Parent_RegistraterCode", c => c.String(maxLength: 20));
            AddColumn("dbo.CUST_Organization", "Parent_RegistraterType", c => c.String(maxLength: 2));
            AddColumn("dbo.CUST_Organization", "Parent_SuperInstitutionsName", c => c.String(nullable: false, maxLength: 80));
            DropForeignKey("dbo.CUST_Parent", "OrganizationId", "dbo.CUST_Organization");
            DropIndex("dbo.CUST_Parent", new[] { "OrganizationId" });
            DropTable("dbo.CUST_Parent");
        }
    }
}
