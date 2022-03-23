using System;
using System.Collections.Generic;

namespace SchoolManagement_WebAPI.Data.Models
{
    public class Student
    {
        // Simple Properties

        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstMidName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        // Navigation Properties
        public List<Enrollment> Enrollments { get; set; }
    }
}