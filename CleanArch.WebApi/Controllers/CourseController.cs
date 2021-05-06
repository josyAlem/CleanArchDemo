using CleanArch.Application.DTO;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
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
