using CleanArch.Application.DTO;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepo;
        public CourseService(ICourseRepository repo)
        {
            _courseRepo = repo;
        }
        public CourseDTO GetCourseById(int Id)
        {
            var x = _courseRepo.GetCourses().FirstOrDefault(c=>c.Id==Id);

            return new CourseDTO()
            {
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl
            };
        }
    }
}
