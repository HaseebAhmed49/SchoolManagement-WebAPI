using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement_WebAPI.Data.Models;
using SchoolManagement_WebAPI.Data.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolManagement_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public StudentsService _studentsSevice;

        public StudentsController(StudentsService studentsService)
        {
            _studentsSevice = studentsService;
        }

        [HttpPost("add-student-with-enrollment")]
        public IActionResult AddStudentWithEnrollments([FromBody]StudentVM student)
        {
            _studentsSevice.AddStudentsWithEnrollments(student);
            return Ok();
        }

        [HttpGet("get-all-students-with-enrollments")]
        public IActionResult GetAllStudentsWithEnrollments()
        {
            var allStudents = _studentsSevice.GetAllStudentsWithEnrollments();
            return Ok(allStudents);
        }

        [HttpGet("get-student-with-enrollment-by-id/{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentsSevice.GetStudentById(id);
            return Ok(student);
        }

        [HttpPut("update-student-by-id/{id}")]
        public IActionResult UpdateStudentById(int id,[FromBody]StudentVM student)
        {
            var updatedStudent = _studentsSevice.UpdateStudentById(id,student);
            return Ok(updatedStudent);
        }

        [HttpDelete("delete-student-by-id/{id}")]
        public IActionResult DeleteStudentById(int id)
        {
            _studentsSevice.DeleteStudentById(id);
            return Ok();
        }
    }
}
