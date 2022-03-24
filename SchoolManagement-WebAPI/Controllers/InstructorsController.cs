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
    public class InstructorsController : ControllerBase
    {
        public InstructorsService _instructorSevice;

        public InstructorsController(InstructorsService instructorService)
        {
            _instructorSevice = instructorService;
        }

        [HttpPost("add-instructor-with-courses")]
        public IActionResult AddInstructor([FromBody]InstructorVM instructor)
        {
            try
            {
                if (String.IsNullOrEmpty(instructor.LastName) || String.IsNullOrEmpty(instructor.FirstMidName)) return BadRequest("First Mid Name or Last Name are not valid");
                _instructorSevice.AddInstructorWithCourses(instructor);
                return Ok(instructor);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        [HttpGet("get-all-instructors")]
        public IActionResult GetAllInstructors()
        {
            try
            {
                var allInstructors = _instructorSevice.GetAllInstructors();
                return (allInstructors.Count > 0) ? Ok(allInstructors) : BadRequest("No Instructors Exists");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("get-instructor-with-courses-by-id/{id}")]
        public IActionResult GetInstructorwithCoursesById(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("Id can't be -ve 0r 0");
                var instructorwithCourses = _instructorSevice.GetInstructorById(id);
                return (instructorwithCourses != null) ? Ok(instructorwithCourses) : BadRequest($"No Instructor Exists against Id: {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("update-instructor-by-id/{id}")]
        public IActionResult UpdateInstructorById(int id,[FromBody]InstructorVM instructor)
        {
            try
            {
                if (id <= 0) return BadRequest("Id can't be -ve 0r 0");
                if (String.IsNullOrEmpty(instructor.LastName) || String.IsNullOrEmpty(instructor.FirstMidName)) return BadRequest("First Mid Name or Last Name are not valid");
                var updatedInstructor = _instructorSevice.UpdateInstructorById(id, instructor);
                return Ok(updatedInstructor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("delete-instructor-by-id/{id}")]
        public IActionResult DeleteInstructorById(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("Id can't be -ve 0r 0");
                _instructorSevice.DeleteInstructorById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}