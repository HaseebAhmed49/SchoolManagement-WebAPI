using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement_WebAPI.Data.Models;
using SchoolManagement_WebAPI.Data.Services;
using SchoolManagement_WebAPI.Data.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolManagement_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("add-department")]
        public IActionResult AddDepartment([FromBody]DepartmentVM department)
        {
            _departmentService.AddDepartment(department);
            return Ok();
        }

        [HttpGet("get-department-with-courses-by-id/{id}")]
        public IActionResult GetDepartmentWithCoursesById(int id)
        {
            var _departmentWithCourses = _departmentService.GetDepartmentWithCourses(id);
            return Ok(_departmentWithCourses);
        }

        [HttpGet("get-all-department-with-courses")]
        public IActionResult GetAllDepartmentWithCoursesById()
        {
            var _departmentWithCourses = _departmentService.GetAllDepartmentWithCourses();
            return Ok(_departmentWithCourses);
        }

    }
}
