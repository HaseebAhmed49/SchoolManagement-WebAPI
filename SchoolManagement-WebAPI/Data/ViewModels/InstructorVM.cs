using System;
using System.Collections.Generic;

namespace SchoolManagement_WebAPI.Data.Models
{
    public class InstructorVM
    {
        public string LastName { get; set; }

        public string FirstMidName { get; set; }

        public List<int> CourseIds { get; set; }
    }
    public class InstructorwithCoursesVM
    {
        public string LastName { get; set; }

        public string FirstMidName { get; set; }

        public List<string> CoursesTitle { get; set; }
    }

}
