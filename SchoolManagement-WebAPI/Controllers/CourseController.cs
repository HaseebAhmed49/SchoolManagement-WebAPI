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
            try
            {
                if (String.IsNullOrEmpty(course.Title)) return BadRequest("Course Title Can't be empty");
                if (course.Credits < 3) return BadRequest($"Credit Hours for Course :{course.Title} should be greater than or equal to 3");
                _courseService.AddCourse(course);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("get-courses-with-department-by-id/{id}")]
        public IActionResult CoursesWithDepartment(int id)
        {
            try
            {
                var _courseWithDepartment = _courseService.GetCourseWithDepartment(id);
                return (_courseWithDepartment != null) ? Ok(_courseWithDepartment) : BadRequest("No Courses Exists");
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        [HttpGet("get-all-courses-with-instructors")]
        public IActionResult GetAllCoursesWithInstructor()
        {
            try
            {
                var _coursesWithInstructors = _courseService.GetAllCoursesWithInstructors();
                return (_coursesWithInstructors.Count > 0) ? Ok(_coursesWithInstructors) : BadRequest("No Courses Exists");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("get-courses-with-instructors-by-id/{id}")]
        public IActionResult CoursesWithInstructor(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("Id can't be -ve 0r 0");
                var _coursesWithInstructors = _courseService.GetInstructorById(id);
                return (_coursesWithInstructors != null) ? Ok(_coursesWithInstructors) : BadRequest($"No Course Exists against Id: {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("update-course-by-id/{id}")]
        public IActionResult UpdateCourseById(int id,[FromBody]CourseVM course)
        {
            try
            {
                if (id <= 0) return BadRequest("Id can't be -ve 0r 0");
                if (String.IsNullOrEmpty(course.Title)) return BadRequest("Course Title Can't be empty");
                if (course.Credits < 3) return BadRequest($"Credit Hours for Course :{course.Title} should be greater than or equal to 3");
                var _updatedCourse = _courseService.UpdateCourseById(id, course);
                return Ok(_updatedCourse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("delete-course-by-id/{id}")]
        public IActionResult DeleteCourseById(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("Id can't be -ve 0r 0");
                _courseService.DeleteCourseById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}
