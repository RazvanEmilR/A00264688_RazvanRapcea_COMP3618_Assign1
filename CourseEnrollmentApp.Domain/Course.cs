using System;
using System.Collections.Generic;
using System.Text;

namespace CourseEnrollmentApp.Domain
{
    public class Course
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public double Credits { get; set; }

        // navigation property
        public ICollection <Enrollment> Enrollments { get; set; }
    }
}
