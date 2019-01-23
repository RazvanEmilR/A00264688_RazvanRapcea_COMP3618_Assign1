using CourseEnrollmentApp.Data;
using CourseEnrollmentApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseEnrollmentAppConsole
{
    class Program
    {
        private static CourseEnrollmentContext _context = new CourseEnrollmentContext(); 

        static void Main(string[] args)
        {
            AddStudent("John", "Doe", "Jerry","A00000001");
            AddStudent("John", "Doe", "Jerry","A00000001");

            AddStudent("Mary", "Poppins", "Jane", "S1");
            AddStudent("John", "Travolta", "Stevens", "S2");

            AddCourse("COMP1", "Advanced C#", 2.5);
            AddCourse("COMP0", "Beginner Java", 1.0);
            AddCourse("COMP2", "Business Analysis", 4.0);

            CreateEnrollment("ENROL0", "COMP0", "S1", 80.4);
            CreateEnrollment("ENROL1", "COMP1", "S1", 70.2);

            RetrieveStudent("S1");

            UpdateStudentInfo("ChangedFirstName", "ChangedLastName", "ChangedMiddlename", "S1");

            RetrieveStudent("S1");

            DeleteStudentRecord("S1");

            RetrieveStudent("S1");

            Console.ReadKey();

        }

        /// <summary>
        /// Creates a student record
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="middleName"></param>
        /// <param name="studentId"></param>
        private  static void AddStudent( string firstName, string lastName, string middleName, string studentId)
        {
    
            var student = _context.Students.FirstOrDefault(st => st.Id == studentId);

            if (student == null)
            {
                student = new Student { FirstName = firstName, LastName = lastName, MiddleName = middleName, EnrollmentDate = DateTime.MinValue, Id = studentId, Enrollments=null};

                try
                {
                    _context.Students.Add(student);
                    _context.SaveChanges();

                    Console.WriteLine("Student added!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Student with respective id already exists!");
            }                   
            
        }

        /// <summary>
        /// Adds a course 
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="title"></param>
        /// <param name="credits"></param>
        private static void AddCourse (string courseId, string title, double credits)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                course = new Course { Id = courseId, Credits = credits, Title = title, Enrollments = null };

                try
                {
                    _context.Courses.Add(course);
                    _context.SaveChanges();

                    Console.WriteLine("Course added!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Course with respective id already exists!");
            }
        }

        /// <summary>
        /// Creates an Enrollment
        /// </summary>
        /// <param name="enrollmentId"></param>
        /// <param name="courseId"></param>
        /// <param name="studentId"></param>
        /// <param name="grade"></param>
        private static void CreateEnrollment(string enrollmentId, string courseId, string studentId, double grade)
        {
          
            var enrollmentDb = _context.Enrollments.FirstOrDefault(en => en.Id == enrollmentId);

            if (enrollmentDb == null)
            {
                var courseDb = _context.Courses.FirstOrDefault(c => c.Id == courseId);

                var studentDb = _context.Students.FirstOrDefault(st => st.Id == studentId);

                if ((courseDb != null) && (studentDb != null))
                {
                    Enrollment enrollment = new Enrollment { Id = enrollmentId, CourseId = courseId, StudentId = studentId, Grade = grade, Course = courseDb, Student = studentDb };
                    studentDb.EnrollmentDate = DateTime.Now;

                    _context.Enrollments.Add(enrollment);
                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Cannot find course or student.");
                }        

            }
            else
            {
                Console.WriteLine("Enrollment already exists.");
            }
        }

        /// <summary>
        /// Gets a student
        /// </summary>
        /// <param name="studentId"></param>
        private static void RetrieveStudent(string studentId)
        {
            bool noRecords = true;
            var students = _context.Students.ToList();

            foreach (var student in students)
            {
                if (student.Id == studentId)
                {
                    noRecords = false;
                    var enrollmentList = student.Enrollments.ToList();

                    Console.WriteLine($"{"Student Id",-20}{"First Name", -20}{"Last Name",-10}{"Enrollment Date", 25}{"Courses", 35}{"Enrollments", 20}");
                    Console.WriteLine(new string('-', 130));
                    Console.WriteLine($"{student.Id, -20}{student.FirstName, -20}{student.LastName, -20}{student.EnrollmentDate, -15}");

                    foreach (Enrollment enrollment in enrollmentList)
                    {
                        Console.WriteLine($"{enrollment.CourseId, 109}{enrollment.Id, 21}");
                    }
                }
            }

            if (noRecords)
                Console.WriteLine("No student with the id provided found.");
        }

        /// <summary>
        /// Updates student information
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="middleName"></param>
        /// <param name="studentId"></param>
        private static void UpdateStudentInfo( string firstName, string lastName, string middleName, string studentId )
        {
            var studentDb = _context.Students.FirstOrDefault(st => st.Id == studentId);

            if (studentDb != null)
            {
                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(middleName))
                {
                    studentDb.FirstName = firstName;
                    studentDb.LastName = lastName;
                    studentDb.MiddleName = middleName;

                    try
                    {
                        _context.SaveChanges();
                        Console.WriteLine("Student information updated.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Student with id entered was not found in records.");
            }                 
        }


        /// <summary>
        /// Deletes a student record
        /// </summary>
        /// <param name="studentId"></param>
        private static void DeleteStudentRecord (string studentId)
        {
            var studentDb = _context.Students.FirstOrDefault(st => st.Id == studentId);

            if (studentDb != null)
            {
                try
                {
                    _context.Students.Remove(studentDb);
                    _context.SaveChanges();

                    Console.WriteLine("Student with id " + studentId + " has been removed from records.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Student with specified id already does not exists in records.");
            }

            
        }

    }
}
