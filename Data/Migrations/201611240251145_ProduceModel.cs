namespace Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ProduceModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PROD_FinancingItem",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FinancingProjectId = c.Guid(nullable: false),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsEdit = c.Boolean(nullable: false),
                        ProduceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PROD_FinancingProject", t => t.FinancingProjectId)
                .ForeignKey("dbo.PROD_Produce", t => t.ProduceId, cascadeDelete: true)
                .Index(t => t.FinancingProjectId)
                .Index(t => t.ProduceId);
            
            CreateTable(
                "dbo.PROD_FinancingProject",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsFinancing = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PROD_Produce",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 200),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RepaymentMethod = c.Byte(nullable: false),
                        MinFinancingRatio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxFinancingRatio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinalRatio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinancingPeriods = c.Int(nullable: false),
                        RepaymentInterval = c.Int(nullable: false),
                        CustomerBailRatio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        Remarks = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PROD_FinancingItem", "ProduceId", "dbo.PROD_Produce");
            DropForeignKey("dbo.PROD_FinancingItem", "FinancingProjectId", "dbo.PROD_FinancingProject");
            DropIndex("dbo.PROD_FinancingItem", new[] { "ProduceId" });
            DropIndex("dbo.PROD_FinancingItem", new[] { "FinancingProjectId" });
            DropTable("dbo.PROD_Produce");
            DropTable("dbo.PROD_FinancingProject");
            DropTable("dbo.PROD_FinancingItem");
        }
    }
}
