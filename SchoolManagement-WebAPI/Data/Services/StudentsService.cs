using System;
using System.Collections.Generic;
using System.Linq;
using SchoolManagement_WebAPI.Data.Models;

namespace SchoolManagement_WebAPI.Data.Services
{
    public class StudentsService
    {
        private AppDBContext _context;
        public StudentsService(AppDBContext context)
        {
            _context = context;
        }

        public void AddStudentsWithEnrollments(StudentVM student)
        {
            var _student = new Student()
            {
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = DateTime.Now                
            };
            _context.Students.Add(_student);
            _context.SaveChanges();

            foreach(var id in student.CourseIds)
            {
                var _enrollment = new Enrollment()
                {
                    Grade = "A",
                    StudentId = _student.Id,
                    CourseId = id                    
                };

                _context.Enrollments.Add(_enrollment);
                _context.SaveChanges();
            }
        }

        #region OldCode
        //public List<Student> GetAllStudents() => _context.Students.ToList();

        //public Student GetStudentById(int id)
        //{
        //    return _context.Students.FirstOrDefault(s => s.Id==id);
        //}
        #endregion

        public List<StudentwithEnrollmentsVM> GetAllStudentsWithEnrollments()
        {
            List<StudentwithEnrollmentsVM> studentwithEnrollmentVMs = new List<StudentwithEnrollmentsVM>();
            var _studentswithEnrollmentVMs = _context.Students.ToList();
            if (_studentswithEnrollmentVMs.Count > 0)
            {
                foreach (var student in _studentswithEnrollmentVMs)
                {
                    var _studentWithEnrollments = _context.Students.Where(s => s.Id == student.Id).Select(student => new StudentwithEnrollmentsVM()
                    {
                        LastName = student.LastName,
                        FirstMidName = student.FirstMidName,
                        CourseTitles = student.Enrollments.Where(n => n.StudentId == student.Id).Select(i => i.Course.Title).ToList()
                        //_context.Courses.Select(ct => ct.Title).ToList()
                    }).FirstOrDefault();
                    studentwithEnrollmentVMs.Add(_studentWithEnrollments);
                }
            }
            return studentwithEnrollmentVMs;
        }


        public StudentwithEnrollmentsVM GetStudentById(int id)
        {
            var _studentWithEnrollments = _context.Students.Where(s => s.Id == id).Select(student => new StudentwithEnrollmentsVM()
            {
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                CourseTitles = student.Enrollments.Where(n => n.StudentId == id).Select(i => i.Course.Title).ToList()
                //_context.Courses.Select(ct => ct.Title).ToList()
            }).FirstOrDefault();
            return _studentWithEnrollments;
        }

        public Student UpdateStudentById(int id,StudentVM student)
        {
            var _student = _context.Students.FirstOrDefault(s => s.Id == id);
            if(_student != null)
            {
                _student.LastName = student.LastName;
                _student.FirstMidName = student.FirstMidName;
                _context.SaveChanges();
            }
            return _student;
        }

        public void DeleteStudentById(int id)
        {
            var _student = _context.Students.FirstOrDefault(s => s.Id == id);
            if(_student !=null)
            {
                _context.Students.Remove(_student);
                _context.SaveChanges();
            }
        }
    }
}
