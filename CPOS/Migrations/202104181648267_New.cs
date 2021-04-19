namespace CPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        CommisionRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OTRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        CanDelete = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CanDelete = c.Boolean(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Users", new[] { "Employee_Id" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropTable("dbo.Users");
            DropTable("dbo.Employees");
        }
    }
}
