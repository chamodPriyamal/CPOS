namespace CPOS.Migrations
{
    using System;
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
            context.Users.AddOrUpdate(usr);
            context.SaveChanges();
        }
    }
}
