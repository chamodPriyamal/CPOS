using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPOS.Model;

namespace CPOS
{
    public class CPOSContext : DbContext
    {
        public CPOSContext() : base("name=DevelopmentDatabase") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}
