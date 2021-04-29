namespace CPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductBatchTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductBatches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Markup = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductBatches", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductBatches", new[] { "Product_Id" });
            DropTable("dbo.ProductBatches");
        }
    }
}
