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
            try
            {
                if (String.IsNullOrEmpty(department.Name)) return BadRequest("Data Not Valid; Name should be defined");
                if (department.Budget <= 0) return BadRequest("Budget can't be 0");
                _departmentService.AddDepartment(department);
                return Ok(department);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("get-department-with-courses-by-id/{id}")]
        public IActionResult GetDepartmentWithCoursesById(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("Id can't be zero");
                var _departmentWithCourses = _departmentService.GetDepartmentWithCourses(id);
                return (_departmentWithCourses != null) ? Ok(_departmentWithCourses) : BadRequest($"No Department Exist against Id: {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        [HttpGet("get-all-department-with-courses")]
        public IActionResult GetAllDepartmentWithCoursesById()
        {
            try
            {
                var _departmentWithCourses = _departmentService.GetAllDepartmentWithCourses();
                return (_departmentWithCourses.Count > 0) ? Ok(_departmentWithCourses) : BadRequest("No Department Exists");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("update-department-by-id/{id}")]
        public IActionResult UpdateDepartmentById(int id,[FromBody]DepartmentVM department)
        {
            try
            {
                if (String.IsNullOrEmpty(department.Name)) return BadRequest("Data Not Valid; Name should be defined");
                if (department.Budget <= 0) return BadRequest("Budget can't be 0");
                var _department = _departmentService.UpdateDepartmentById(id, department);
                return Ok(_department);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        [HttpDelete("delete-department-by-id/{id}")]
        public IActionResult DeleteDepartmentById(int id)
        {
            try
            { 
            _departmentService.DeleteDepartmentById(id);
            return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}
