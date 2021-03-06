namespace CPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductTable : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: false)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropTable("dbo.Products");
        }
    }
}
