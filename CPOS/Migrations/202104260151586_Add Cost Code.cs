namespace CPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCostCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "CostCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "CostCode");
        }
    }
}
