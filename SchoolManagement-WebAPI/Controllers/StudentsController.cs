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
            try
            {
                if (String.IsNullOrEmpty(student.LastName) || String.IsNullOrEmpty(student.FirstMidName)) return BadRequest("First Mid Name or Last Name are not valid");
                _studentsSevice.AddStudentsWithEnrollments(student);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("get-all-students-with-enrollments")]
        public IActionResult GetAllStudentsWithEnrollments()
        {
            try
            {
                var allStudents = _studentsSevice.GetAllStudentsWithEnrollments();
                return (allStudents.Count > 0) ? Ok(allStudents) : BadRequest("No Student Exists");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("get-student-with-enrollment-by-id/{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("Id can't be -ve 0r 0");
                var student = _studentsSevice.GetStudentById(id);
                return (student != null) ? Ok(student) : BadRequest($"No Student exists in DB against Id: {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("update-student-by-id/{id}")]
        public IActionResult UpdateStudentById(int id,[FromBody]StudentVM student)
        {
            if (id <= 0) return BadRequest("Id can't be -ve 0r 0");
            if (String.IsNullOrEmpty(student.LastName) || String.IsNullOrEmpty(student.FirstMidName)) return BadRequest("First Mid Name or Last Name are not valid");
            var updatedStudent = _studentsSevice.UpdateStudentById(id,student);
            return Ok(updatedStudent);
        }

        [HttpDelete("delete-student-by-id/{id}")]
        public IActionResult DeleteStudentById(int id)
        {
            if (id <= 0) return BadRequest("Id can't be -ve 0r 0");
            _studentsSevice.DeleteStudentById(id);
            return Ok();
        }
    }
}
