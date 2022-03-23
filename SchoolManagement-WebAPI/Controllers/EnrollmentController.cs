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
    public class EnrollmentController : ControllerBase
    {
        private EnrollmentService _enrollmentService;

        public EnrollmentController(EnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost]
        public IActionResult AddEnrollment([FromBody]EnrollmentVM enrollment)
        {
            _enrollmentService.AddEnrollment(enrollment);
            return Ok();
        }
    }
}
