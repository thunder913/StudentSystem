using System.Data.Entity;
using StudentSystemCommon.Migrations;
using StudentSystemCommon.MVVM.Model.DB;
namespace StudentSystemCommon.DAL
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("StudentSystemDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentContext, Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
