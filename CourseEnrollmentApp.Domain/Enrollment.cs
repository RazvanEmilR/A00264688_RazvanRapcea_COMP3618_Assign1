using System;
using System.Collections.Generic;
using System.Text;

namespace CourseEnrollmentApp.Domain
{
    public class Enrollment
    {
        public string Id { get; set; }

        public string CourseId { get; set; }

        public string StudentId { get; set; }

        public double Grade { get; set; }

        // navigation properties
        public Course Course { get; set; }

        public Student Student { get; set; }
    }
}
