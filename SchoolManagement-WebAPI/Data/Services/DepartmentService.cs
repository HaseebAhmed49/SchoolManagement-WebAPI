using System;
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
                StartDate = department.StartDate,                
            };
            _context.Department.Add(_department);
            _context.SaveChanges();
        }
    }
}
