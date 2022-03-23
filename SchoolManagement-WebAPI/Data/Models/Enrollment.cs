using System;
namespace SchoolManagement_WebAPI.Data.Models
{
    public class Enrollment
    {
        public int Id { get; set; }


        public string Grade { get; set; }

        // Navigation Properties
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int? CourseId { get; set; }

        public Course Course { get; set; }
    }
}
