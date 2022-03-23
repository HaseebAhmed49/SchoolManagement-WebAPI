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
            _instructorSevice.AddInstructorWithCourses(instructor);
            return Ok();
        }

        [HttpGet("get-all-instructors")]
        public IActionResult GetAllInstructors()
        {
            var allInstructors = _instructorSevice.GetAllInstructors();
            return Ok(allInstructors);
        }

        //[HttpGet("get-instructor-by-id/{id}")]
        //public IActionResult GetInstructorById(int id)
        //{
        //    var instructor = _instructorSevice.GetInstructorById(id);
        //    return Ok(instructor);
        //}

        [HttpGet("get-instructor-with-courses-by-id/{id}")]
        public IActionResult GetInstructorwithCoursesById(int id)
        {
            var instructorwithCourses = _instructorSevice.GetInstructorById(id);
            return Ok(instructorwithCourses);
        }

        [HttpPut("update-instructor-by-id/{id}")]
        public IActionResult UpdateInstructorById(int id,[FromBody]InstructorVM instructor)
        {
            var updatedInstructor = _instructorSevice.UpdateInstructorById(id,instructor);
            return Ok(updatedInstructor);
        }

        [HttpDelete("delete-instructor-by-id/{id}")]
        public IActionResult DeleteInstructorById(int id)
        {
            _instructorSevice.DeleteInstructorById(id);
            return Ok();
        }
    }
}
