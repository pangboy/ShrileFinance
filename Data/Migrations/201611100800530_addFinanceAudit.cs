namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFinanceAudit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Finance_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.Finance_Id)
                .Index(t => t.Finance_Id);
            
            CreateTable(
                "dbo.FinanceAudit",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ManufacturerGuidePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApprovalValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdviceMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdviceRatio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApprovalMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApprovalRatio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Poundage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinanceId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FANC_Finance", t => t.FinanceId, cascadeDelete: true)
                .Index(t => t.FinanceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinanceAudit", "FinanceId", "dbo.FANC_Finance");
            DropForeignKey("dbo.Contact", "Finance_Id", "dbo.FANC_Finance");
            DropIndex("dbo.FinanceAudit", new[] { "FinanceId" });
            DropIndex("dbo.Contact", new[] { "Finance_Id" });
            DropTable("dbo.FinanceAudit");
            DropTable("dbo.Contact");
        }
    }
}
