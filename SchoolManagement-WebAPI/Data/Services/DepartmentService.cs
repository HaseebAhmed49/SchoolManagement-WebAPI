using System;
using System.Collections.Generic;
using System.Linq;
using SchoolManagement_WebAPI.Data.Models;
using SchoolManagement_WebAPI.Data.ViewModels;

namespace SchoolManagement_WebAPI.Data.Services
{
    public class DepartmentService
    {
        private AppDBContext _context;
        public DepartmentService(AppDBContext context)
        {
            _context = context;
        }

        public void AddDepartment(DepartmentVM department)
        {
            var _department = new Department()
            {
                Name = department.Name,
                Budget = department.Budget,
                StartDate = DateTime.Now,                
            };
            _context.Department.Add(_department);
            _context.SaveChanges();
        }

        public DepartmentWithCoursesVM GetDepartmentWithCourses(int id)
        {
            var _departmentwithCourses = _context.Department.Where(d => d.Id == id).Select(department => new DepartmentWithCoursesVM()
            {
                Id = department.Id,
                Name = department.Name,
                Budget = department.Budget,
                StartDate = department.StartDate,
                CoursesTitle = department.Courses.Where(c => c.DepartmentId == department.Id).Select(ct=>ct.Title).ToList()
            }).FirstOrDefault();
            return _departmentwithCourses;
        }

        public List<DepartmentWithCoursesVM> GetAllDepartmentWithCourses()
        {
            List<DepartmentWithCoursesVM> departmentsWithCoursesVMs = new List<DepartmentWithCoursesVM>();
            var _departmentWithCourses = _context.Department.ToList();
            if(_departmentWithCourses.Count > 0)
            {
                foreach (var department in _departmentWithCourses)
                {
                    var _department = _context.Department.Where(d => d.Id == department.Id).Select(department => new DepartmentWithCoursesVM()
                    {
                        Id = department.Id,
                        Name = department.Name,
                        Budget = department.Budget,
                        StartDate = department.StartDate,
                        CoursesTitle = department.Courses.Where(c => c.DepartmentId == department.Id).Select(ct => ct.Title).ToList()
                    }).FirstOrDefault();
                    departmentsWithCoursesVMs.Add(_department);
                }
            }
            return departmentsWithCoursesVMs;
        }

        public Department UpdateDepartmentById(int id,DepartmentVM department)
        {
            var _department = _context.Department.FirstOrDefault(d => d.Id == id);
            if(_department != null)
            {
                _department.Name = department.Name;
                _department.Budget = department.Budget;
                _context.SaveChanges();
            }
            return _department;
        }

        public void DeleteDepartmentById(int id)
        {
            var _department = _context.Department.FirstOrDefault(d => d.Id == id);
            if (_department != null)
            {
                _context.Department.Remove(_department);
                _context.SaveChanges();
            }
        }

        public List<DepartmentVM> GetAllDepartments()
        {
            var _departments = _context.Department.Select(department => new DepartmentVM()
            {
                Name = department.Name,
                Budget = department.Budget,
                StartDate = department.StartDate
            }).ToList();
            return _departments;
        }
    }
}
