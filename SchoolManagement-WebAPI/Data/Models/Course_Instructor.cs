using System;
namespace SchoolManagement_WebAPI.Data.Models
{
    public class Course_Instructor
    {
        public int Id { get; set; }

        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
