using Microsoft.EntityFrameworkCore;
using Student_MVC.Models;

namespace Student_MVC.Db
{
    public class AppDb : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=MSI\SQLEXPRESS;Database=StudentMVC;Trusted_Connection=True;");
        }
    }
}
