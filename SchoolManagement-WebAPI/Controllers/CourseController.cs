using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement_WebAPI.Data.Services;
using SchoolManagement_WebAPI.Data.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolManagement_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private CourseServices _courseService;

        public CourseController(CourseServices courseServices)
        {
            _courseService = courseServices;
        }

        [HttpPost("add-course")]
        public IActionResult AddCourse([FromBody]CourseVM course)
        {
            _courseService.AddCourse(course);
            return Ok();
        }

        [HttpGet("get-all-courses-with-instructors")]
        public IActionResult GetAllCoursesWithInstructor()
        {
            var _coursesWithInstructors = _courseService.GetAllCoursesWithInstructors();
            return Ok(_coursesWithInstructors);
        }

        [HttpGet("get-courses-with-instructors-by-id/{id}")]
        public IActionResult CoursesWithInstructor(int id)
        {
            var _coursesWithInstructors = _courseService.GetInstructorById(id);
            return Ok(_coursesWithInstructors);
        }

        [HttpPut("update-course-by-id/{id}")]
        public IActionResult UpdateCourseById(int id,[FromBody]CourseVM course)
        {
            var _updatedCourse = _courseService.UpdateCourseById(id, course);
            return Ok(_updatedCourse);
        }

        [HttpDelete("delete-course-by-id/{id}")]
        public IActionResult DeleteCourseById(int id)
        {
            _courseService.DeleteCourseById(id);
            return Ok();
        }

    }
}
