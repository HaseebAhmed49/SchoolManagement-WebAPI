using System;
using Microsoft.EntityFrameworkCore;
using SchoolManagement_WebAPI.Data.Models;

namespace SchoolManagement_WebAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course_Instructor>()
                .HasOne(c => c.Course)
                .WithMany(ci => ci.Course_Instructors)
                .HasForeignKey(ci => ci.CourseId);

            modelBuilder.Entity<Course_Instructor>()
    .HasOne(i => i.Instructor)
    .WithMany(ci => ci.Course_Instructors)
    .HasForeignKey(iid => iid.InstructorId);

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Instructor> instructors { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Course_Instructor> Course_Instructors { get; set; }
    }
}
