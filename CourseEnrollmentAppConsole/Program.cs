using CourseEnrollmentApp.Data;
using CourseEnrollmentApp.Domain;
using System;

namespace CourseEnrollmentAppConsole
{
    class Program
    {
        private static CourseEnrollmentContext _context = new CourseEnrollmentContext(); 

        static void Main(string[] args)
        {
            CreateStudent();
            Console.ReadKey();
        }

        private static void CreateStudent()
        {
            // DateTime enrollmentDate = new DateTime(2019, 0, 1);
            DateTime enrollmentDate = DateTime.Now;
            var student = new Student { FirstName = "John", LastName = "Doe", MiddleName = "Smith", EnrollmentDate = enrollmentDate, Enrollments = null, Id = "A000000001" };

            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
