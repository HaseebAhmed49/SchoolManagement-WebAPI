using System;
using SchoolManagement_WebAPI.Data.Models;
using SchoolManagement_WebAPI.Data.ViewModels;

namespace SchoolManagement_WebAPI.Data.Services
{
    public class EnrollmentService
    {
        private AppDBContext _context;
        public EnrollmentService(AppDBContext context)
        {
            _context = context;
        }

        public void AddEnrollment(EnrollmentVM enrollment)
        {
            var _enrollment = new Enrollment()
            {
                Grade = enrollment.Grade
            };
            _context.Enrollments.Add(_enrollment);
            _context.SaveChanges();
        }

    }
}
