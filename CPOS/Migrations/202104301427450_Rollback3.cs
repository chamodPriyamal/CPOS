namespace CPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rollback3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.ProductBatches", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductBatches", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropTable("dbo.ProductBatches");
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ReOrderLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BarcodeImage = c.Binary(nullable: false),
                        BarcodeData = c.String(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Products", "Category_Id");
            CreateIndex("dbo.ProductBatches", "Product_Id");
            AddForeignKey("dbo.ProductBatches", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
