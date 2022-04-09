using System;
using System.Collections.Generic;

namespace SchoolManagement_WebAPI.Data.Models
{
    public class StudentVM
    {
        public string LastName { get; set; }

        public string FirstMidName { get; set; }

        public List<int> CourseIds { get; set; }
    }

    public class StudentwithEnrollmentsVM
    {
        public string LastName { get; set; }

        public string FirstMidName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public List<string> CourseTitles { get; set; }
    }

}