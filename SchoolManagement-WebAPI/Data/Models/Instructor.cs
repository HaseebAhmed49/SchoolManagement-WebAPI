using System;
using System.Collections.Generic;

namespace SchoolManagement_WebAPI.Data.Models
{
    public class Instructor
    {
        // Simple Properties

        public int Id { get; set; }

        public string LastName { get; set; }
        
        public string FirstMidName { get; set; }

        public DateTime HireDate { get; set; }

        // Navigation Properties
        public List<Course_Instructor> Course_Instructors { get; set; }

    }

}
