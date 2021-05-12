using CleanArch.Application.Common;
using CleanArch.Application.DTO;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CleanArch.WebApi.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService _courseSvc;
        private IConfiguration _config;
        public CourseController(ICourseService courseService, IConfiguration configuration)
        {
            _courseSvc = courseService;
            _config = configuration;
        }
        [HttpGet("{Id}")]
        public ActionResult<CourseDTO> GetCourseById(int Id)
        {
            try
            {
                var course = _courseSvc.GetCourseById(Id);
                return Ok(course);
            }
            catch (Exception ex)
            {

                ObjectResult result = new ObjectResult(new ResponseObject(ex.Message));
                result.StatusCode = (int)HttpStatusCode.BadRequest;
                return result;
            }
        }

        [Route("add")]
        [HttpPost]
        public ActionResult<CourseDTO> AddCourse([FromBody] CourseDTO courseDto)
        {
            var course = _courseSvc.AddCourse(courseDto);
            return Ok(course);
        }
        [Route("update")]
        [HttpPut]
        public ActionResult<CourseDTO> UpdateCourse([FromBody] CourseDTO courseDto)
        {
            try
            {
                var course = _courseSvc.UpdateCourse(courseDto);
                return Ok(course);
            }
            catch (Exception ex)
            {

                ObjectResult result = new ObjectResult(new ResponseObject(ex.Message));
                result.StatusCode = (int)HttpStatusCode.BadRequest;
                return result;
            }
        }
        [Route("remove/{id}")]
        [HttpDelete]
        public ActionResult<CourseDTO> RemoveCourse(int id)
        {
            try
            {
                _courseSvc.RemoveCourse(id);
                return Ok();
            }
            catch (Exception ex)
            {

                ObjectResult result = new ObjectResult(new ResponseObject(ex.Message));
                result.StatusCode = (int)HttpStatusCode.BadRequest;
                return result;
            }
        }

        [Route("upload")]
        [HttpPost]
        public async Task<ActionResult<CourseDTO>> Upload([FromForm]IFormFile formFile)
        {
            try
            {
                ValidateUploadedFile(formFile);
                var filePath = Path.GetTempFileName();
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                }

                // Process uploaded files
                // Don't rely on or trust the FileName property without validation.

                return Ok(new { filepath = filePath });
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        private void ValidateUploadedFile(IFormFile formFile)
        {

            if (formFile == null)
                throw new Exception("File not specified for upload!");
            long filenameLengthLimit = _config.GetValue<long>("UploadFileRules:FileNameLengthLimit");
            if (formFile.FileName.Trim().Length > filenameLengthLimit)
                throw new Exception($"File name length must be less than {filenameLengthLimit}!");

            long minFileSize = _config.GetValue<long>("UploadFileRules:MinFileSize");
            long maxFileSize = _config.GetValue<long>("UploadFileRules:MaxFileSize");
            if (formFile.Length <= minFileSize || formFile.Length > maxFileSize)
                throw new Exception($"File size must be between {minFileSize} and {maxFileSize}!");

            string allowedExtensions = _config.GetValue<string>("UploadFileRules:AllowedExtensions");
            string fileExt = Path.GetExtension(formFile.FileName.Trim()).ToLowerInvariant();
           
            if (string.IsNullOrEmpty(fileExt) || !allowedExtensions.Split(",").Contains(fileExt))
            {
                throw new Exception($"File type must be any of [ {allowedExtensions}]!");

            }
        }
    }
}
