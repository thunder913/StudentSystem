using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Migrations;
using StudentSystem.MVVM.Model.DB;
namespace StudentSystem.DAL
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("StudentSystemDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentContext, Configuration>());
        }

        public DbSet<User> Users { get; set; }
    }
}
