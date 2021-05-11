using CleanArch.Application.DTO;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepo;
        public CourseService(ICourseRepository repo)
        {
            _courseRepo = repo;
        }
        public CourseDTO GetCourseById(int id)
        {
            var x = _courseRepo.GetById(id);

            return new CourseDTO()
            {
               Id=id,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl
            };
        }
        public CourseDTO AddCourse(CourseDTO courseDTO)
        {
          
                Course course = new Course()
                {
                    Name = courseDTO.Name,
                    Description = courseDTO.Description,
                    ImageUrl = courseDTO.ImageUrl
                };
                var result = _courseRepo.Add(course);
                
                return new CourseDTO()
                {
               Id= result.Id,
                    Name = result.Name,
                    Description = result.Description,
                    ImageUrl = result.ImageUrl
                };
             }
        public CourseDTO UpdateCourse(CourseDTO courseDTO)
        {
            if (courseDTO.Id == 0)
                throw new Exception("Course Id Not Specified");

            Course course = new Course()
            {
               Id=courseDTO.Id,
                Name = courseDTO.Name,
                Description = courseDTO.Description,
                ImageUrl = courseDTO.ImageUrl
            };
            var result = _courseRepo.Update(course);

            return new CourseDTO()
            {
               Id= result.Id,
                Name = result.Name,
                Description = result.Description,
                ImageUrl = result.ImageUrl
            };
           
        }
        public void RemoveCourse(int id)
        {
            
            _courseRepo.Remove(id);
        }
    }
}
