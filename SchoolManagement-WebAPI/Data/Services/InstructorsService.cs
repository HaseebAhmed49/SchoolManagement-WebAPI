using System;
using System.Collections.Generic;
using System.Linq;
using SchoolManagement_WebAPI.Data.Models;

namespace SchoolManagement_WebAPI.Data.Services
{
    public class InstructorsService
    {
        private AppDBContext _context;
        public InstructorsService(AppDBContext context)
        {
            _context = context;
        }

        public void AddInstructorWithCourses(InstructorVM instructor)
        {
            var _instructor = new Instructor()
            {
                LastName = instructor.LastName,
                FirstMidName = instructor.FirstMidName,
                HireDate = DateTime.Now
            };
            _context.instructors.Add(_instructor);
            _context.SaveChanges();

            foreach(var id in instructor.CourseIds)
            {
                var _course_instructor = new Course_Instructor()
                {
                    InstructorId = _instructor.Id,
                    CourseId = id
                };
                _context.Course_Instructors.Add(_course_instructor);
                _context.SaveChanges();
            }
        }

        public List<Instructor> GetAllInstructors() => _context.instructors.ToList();

        public InstructorwithCoursesVM GetInstructorById(int id)
        {
            var _instructorWithCourse = _context.instructors.Where(i => i.Id == id).Select(instructor => new InstructorwithCoursesVM()
            {
                LastName = instructor.LastName,
                FirstMidName = instructor.FirstMidName,
                //HireDate = instructor.HireDate,
                CoursesTitle = instructor.Course_Instructors.Select(c => c.Course.Title).ToList()
            }).FirstOrDefault();
            return _instructorWithCourse;
        }

////        This code will only show the instructors but not courses
//        public Instructor GetInstructorById(int id)
//        {
//            return _context.instructors.FirstOrDefault(i => i.Id==id);
//        }

        public Instructor UpdateInstructorById(int id,InstructorVM instructor)
        {
            var _instructor = _context.instructors.FirstOrDefault(i => i.Id == id);
            if(_instructor != null)
            {
                _instructor.LastName = instructor.LastName;
                _instructor.FirstMidName = instructor.FirstMidName;
                _context.SaveChanges();
            }
            return _instructor;
        }

        public void DeleteInstructorById(int id)
        {
            var _instructor = _context.instructors.FirstOrDefault(i => i.Id == id);
            if(_instructor !=null)
            {
                _context.instructors.Remove(_instructor);
                _context.SaveChanges();
            }
        }
    }
}
