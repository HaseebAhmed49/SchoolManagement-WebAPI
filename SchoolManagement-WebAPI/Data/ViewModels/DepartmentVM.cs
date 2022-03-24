using System;
using System.Collections.Generic;

namespace SchoolManagement_WebAPI.Data.Models
{
    public class DepartmentVM
    {
        public string Name { get; set; }

        public int Budget { get; set; }

        public DateTime StartDate { get; set; }
    }

    public class DepartmentWithCoursesVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Budget { get; set; }

        public DateTime StartDate { get; set; }

        public List<string> CoursesTitle { get; set; }
    }
}