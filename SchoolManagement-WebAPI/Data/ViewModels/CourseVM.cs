using System;
using System.Collections.Generic;

namespace SchoolManagement_WebAPI.Data.ViewModels
{
    public class CourseVM
    {
        public string Title { get; set; }

        public int Credits { get; set; }
    }

    public class CoursewithInstructorVM
    {
        public string Title { get; set; }

        public int Credits { get; set; }

        public List<string> InstructorNames { get; set; }
    }

}
