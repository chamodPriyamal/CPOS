namespace CPOS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Model;

    internal sealed class Configuration : DbMigrationsConfiguration<CPOS.CPOSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CPOS.CPOSContext context)
        {
            context.Database.Delete();
            context.Database.Create();
            
            List<Permission> Permissions = new List<Permission>();
            Permissions.Add(new Permission { Code = 1, Name = "LOGIN" });
            Permissions.Add(new Permission { Code = 2, Name = "PRODUCT_CATEGORY_VIEW" });
            Permissions.Add(new Permission { Code = 3, Name = "PRODUCT_CATEGORY_ADD" });
            Permissions.Add(new Permission { Code = 4, Name = "PRODUCT_CATEGORY_EDIT" });
            Permissions.Add(new Permission { Code = 5, Name = "PRODUCT_CATEGORY_DELETE" });

            Permissions.Add(new Permission { Code = 6, Name = "CUSTOMER_VIEW" });
            Permissions.Add(new Permission { Code = 7, Name = "CUSTOMER_ADD" });
            Permissions.Add(new Permission { Code = 8, Name = "CUSTOMER_EDIT" });
            Permissions.Add(new Permission { Code = 9, Name = "CUSTOMER_DELETE" });

            Permissions.Add(new Permission { Code = 10, Name = "PRODUCT_ADD" });
            Permissions.Add(new Permission { Code = 11, Name = "PRODUCT_VIEW" });
            Permissions.Add(new Permission { Code = 12, Name = "PRODUCT_EDIT" });
            Permissions.Add(new Permission { Code = 13, Name = "PRODUCT_DELETE" });

            Permissions.Add(new Permission { Code = 14, Name = "PRODUCT_BATCH_ADD" });
            Permissions.Add(new Permission { Code = 15, Name = "PRODUCT_BATCH_VIEW" });
            Permissions.Add(new Permission { Code = 16, Name = "PRODUCT_BATCH_EDIT" });
            Permissions.Add(new Permission { Code = 17, Name = "PRODUCT_BATCH_DELETE" });


            //Add Default Employee
            Employee emp = new Employee();
            emp.Name = "Administrator";
            emp.Address = "-";
            emp.Mobile = "-";
            emp.CommisionRate = 0;
            emp.OTRate = 0;
            emp.IsActive = true;
            emp.CanDelete = false;
            emp.CreatedDate = DateTime.Now;
            emp.LastUpdate = DateTime.Now;
            context.Employees.AddOrUpdate(emp);
            context.SaveChanges();

            //Add Default User
            User usr = new User();
            usr.Username = "admin";
            usr.Password = "admin";
            usr.CanDelete = false;
            usr.IsActive = true;
            usr.LastLogin = DateTime.Now;
            usr.LastUpdate = DateTime.Now;
            usr.CreatedDate = DateTime.Now;
            usr.Employee = emp;
            usr.Permissions = Permissions;
            context.Users.AddOrUpdate(usr);
            context.SaveChanges();

            //Add Default Settings
            Settings s = new Settings();
            s.Id = 1;
            s.BusinessName = "TechWiz Inc.";
            s.BusinessAddress = "Main Street - Padavi Parakramapura";
            s.BusinessContact = "071 790 8311 / 070 591 0695";
            s.CostCode = "pqsrnmwzxv/";
            context.Settings.AddOrUpdate(s);
            context.SaveChanges();

            //Add Default Category
            Category cat = new Category();
            cat.Id = 1;
            cat.Name = "Default";
            context.Categories.AddOrUpdate(cat);
            context.SaveChanges();

            //Add Default Customer
            Customer cust = new Customer();
            cust.Id = 1;
            cust.Name = "Walk-In";
            cust.Address = "-";
            cust.Mobile = "0000000000";
            cust.Nic = "0";
            cust.LandLine = "0";
            context.Customers.AddOrUpdate(cust);
            context.SaveChanges();
        }
    }
}
