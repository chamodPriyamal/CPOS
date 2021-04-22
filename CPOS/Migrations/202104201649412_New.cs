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
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false),
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
            
            CreateTable(
                "dbo.UserPermissions",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Permission_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Permission_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Permissions", t => t.Permission_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Permission_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPermissions", "Permission_Id", "dbo.Permissions");
            DropForeignKey("dbo.UserPermissions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.UserPermissions", new[] { "Permission_Id" });
            DropIndex("dbo.UserPermissions", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Employee_Id" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropTable("dbo.UserPermissions");
            DropTable("dbo.Users");
            DropTable("dbo.Permissions");
            DropTable("dbo.Employees");
        }
    }
}
