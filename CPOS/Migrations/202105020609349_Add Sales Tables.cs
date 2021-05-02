namespace CPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalesTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaleDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_Id = c.Int(nullable: false),
                        ProductBatch_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: false)
                .ForeignKey("dbo.ProductBatches", t => t.ProductBatch_Id, cascadeDelete: false)
                .Index(t => t.Product_Id)
                .Index(t => t.ProductBatch_Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrandTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cashier_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        Representive_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Cashier_Id, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.Representive_Id, cascadeDelete: false)
                .Index(t => t.Cashier_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Representive_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "Representive_Id", "dbo.Employees");
            DropForeignKey("dbo.Sales", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Sales", "Cashier_Id", "dbo.Employees");
            DropForeignKey("dbo.SaleDetails", "ProductBatch_Id", "dbo.ProductBatches");
            DropForeignKey("dbo.SaleDetails", "Product_Id", "dbo.Products");
            DropIndex("dbo.Sales", new[] { "Representive_Id" });
            DropIndex("dbo.Sales", new[] { "Customer_Id" });
            DropIndex("dbo.Sales", new[] { "Cashier_Id" });
            DropIndex("dbo.SaleDetails", new[] { "ProductBatch_Id" });
            DropIndex("dbo.SaleDetails", new[] { "Product_Id" });
            DropTable("dbo.Sales");
            DropTable("dbo.SaleDetails");
        }
    }
}
