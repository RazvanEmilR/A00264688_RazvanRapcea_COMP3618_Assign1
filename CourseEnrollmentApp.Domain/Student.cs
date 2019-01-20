using System;
using System.Collections.Generic;
using System.Text;

namespace CourseEnrollmentApp.Domain
{
    public class Student
    {
        public string Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        //navigation property
        public ICollection<Enrollment>  Enrollments { get; set; }
    }
}
