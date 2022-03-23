using System;
using System.Collections.Generic;

namespace SchoolManagement_WebAPI.Data.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Budget { get; set; }

        public DateTime StartDate { get; set; }

        public List<Course> Courses { get; set; }
    }
}