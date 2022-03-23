using System;
namespace SchoolManagement_WebAPI.Data.Models
{
    public class EnrollmentVM
    {
        public string Grade { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }
    }
}
