namespace CPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "CanDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "LastUpdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "LastUpdate");
            DropColumn("dbo.Employees", "CreatedDate");
            DropColumn("dbo.Employees", "CanDelete");
            DropColumn("dbo.Employees", "IsActive");
        }
    }
}
