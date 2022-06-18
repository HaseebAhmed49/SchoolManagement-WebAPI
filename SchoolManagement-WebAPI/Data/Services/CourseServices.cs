using System;
using System.Collections.Generic;
using System.Linq;
using SchoolManagement_WebAPI.Data.Models;
using SchoolManagement_WebAPI.Data.ViewModels;

namespace SchoolManagement_WebAPI.Data.Services
{
    public class CourseServices
    {
        private AppDBContext _context;
        public CourseServices(AppDBContext context)
        {
            _context = context;
        }

        public void AddCourse(CourseVM course)
        {
            var _course = new Course()
            {
                Title = course.Title,
                Credits = course.Credits,
                DepartmentId = course.DeparmentId
            };
            _context.Courses.Add(_course);
            _context.SaveChanges();
        }

        public List<CoursewithInstructorVM> GetAllCoursesWithInstructors()
        {
            List<CoursewithInstructorVM> coursewithInstructorVMs = new List<CoursewithInstructorVM>();
            var _CoursesWithInstructor = _context.Courses.ToList();
            if (_CoursesWithInstructor.Count > 0)
            {
                foreach (var course in _CoursesWithInstructor)
                {
                    var _CourseWithinstructor = _context.Courses.Where(c => c.Id == course.Id).Select(course => new CoursewithInstructorVM()
                    {
                        Title = course.Title,
                        Credits = course.Credits,
                        InstructorNames = course.Course_Instructors.Select(i => i.Instructor.LastName).ToList()
                    }).FirstOrDefault();
                    coursewithInstructorVMs.Add(_CourseWithinstructor);
                }
            }
            return coursewithInstructorVMs;
        }

        public CoursewithInstructorVM GetInstructorById(int id)
        {
            var _CourseWithinstructor = _context.Courses.Where(c => c.Id == id).Select(course => new CoursewithInstructorVM()
            {
                Title = course.Title,
                Credits = course.Credits,
                InstructorNames = course.Course_Instructors.Select(i => i.Instructor.LastName).ToList()
            }).FirstOrDefault();
            return _CourseWithinstructor;
        }

        public Course UpdateCourseById(int id,CourseVM course)
        {
            var _course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if(_course!=null)
            {
                _course.Title = course.Title;
                _course.Credits = course.Credits;
                _course.DepartmentId = course.DeparmentId;
                _context.SaveChanges();
            }
            return _course;
        }

        public void DeleteCourseById(int id)
        {
            var _course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (_course != null)
            {
                _context.Courses.Remove(_course);
                _context.SaveChanges();
            }
        }
    }
}