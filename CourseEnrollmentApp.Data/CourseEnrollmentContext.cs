using CourseEnrollmentApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseEnrollmentApp.Data
{
    public class CourseEnrollmentContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = RAZVAN-SONY-LAP; Database=CourseEnrollmentData; Trusted_Connection=True; ");
        }
    }
}
