using CleanArch.Application.Common;
using CleanArch.Application.DTO;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace CleanArch.WebApi.Controllers
{
    [Route("api/course")]
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
            try{var course = _courseSvc.GetCourseById(Id);
            return Ok(course);
        }
            catch (Exception ex) {
               
                ObjectResult result = new ObjectResult(new ResponseObject(ex.Message));
        result.StatusCode = (int) HttpStatusCode.BadRequest;
                return result;
            }
}

    [Route("add")]
        [HttpPost]
        public ActionResult<CourseDTO> AddCourse([FromBody]CourseDTO courseDto)
        {
            var course = _courseSvc.AddCourse(courseDto);
            return Ok(course);
        }
        [Route("update")]
        [HttpPut]
        public ActionResult<CourseDTO> UpdateCourse([FromBody] CourseDTO courseDto)
        {
            try {
                var course = _courseSvc.UpdateCourse(courseDto);
                return Ok(course);
            }
            catch (Exception ex) {
               
                ObjectResult result= new ObjectResult(new ResponseObject(ex.Message));
                result.StatusCode = (int)HttpStatusCode.BadRequest;
                return result;
            }
        }
        [Route("remove/{id}")]
        [HttpDelete]
        public ActionResult<CourseDTO> RemoveCourse(int id)
        {
            try{ _courseSvc.RemoveCourse(id);
            return Ok();
        }
            catch (Exception ex) {
               
                ObjectResult result = new ObjectResult(new ResponseObject(ex.Message));
        result.StatusCode = (int) HttpStatusCode.BadRequest;
                return result;
            }
}
    }
}
