using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private UniversityDbContext _uCtx;
        public CourseRepository(UniversityDbContext ctx)
        {
            _uCtx = ctx;
        }
        public IEnumerable<Course> GetCourses() {
           return _uCtx.Courses; 
        }
    }
}
