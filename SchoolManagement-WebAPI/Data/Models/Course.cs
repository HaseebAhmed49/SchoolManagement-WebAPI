using System;
using System.Collections.Generic;

namespace SchoolManagement_WebAPI.Data.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        // Navigation Properties
        public List<Course_Instructor> Course_Instructors { get; set; }

        public List<Enrollment> Enrollments { get; set; }
    }
}
