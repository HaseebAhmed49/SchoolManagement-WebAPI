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
}