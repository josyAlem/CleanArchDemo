using CleanArch.Application.DTO;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.WebApi.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController:ControllerBase
    {
        private ICourseService _courseSvc;
        public CourseController(ICourseService courseService)
        {
            _courseSvc = courseService;
        }
      [HttpGet("{Id}")]
        public ActionResult<CourseDTO> GetCourseById(int Id)
        {
            var course = _courseSvc.GetCourseById(Id);
            return Ok(course);
        }
    }
}
