namespace CPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalesTables1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SaleDetails", "Sale_Id", c => c.Int());
            CreateIndex("dbo.SaleDetails", "Sale_Id");
            AddForeignKey("dbo.SaleDetails", "Sale_Id", "dbo.Sales", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleDetails", "Sale_Id", "dbo.Sales");
            DropIndex("dbo.SaleDetails", new[] { "Sale_Id" });
            DropColumn("dbo.SaleDetails", "Sale_Id");
        }
    }
}
