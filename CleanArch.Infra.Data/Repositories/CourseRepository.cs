using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System.Linq;

namespace CleanArch.Infra.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private UniversityDbContext _uCtx;
        public CourseRepository(UniversityDbContext ctx)
        {
            _uCtx = ctx;
        }
        public Course GetCourseById(int Id) {
            var course = _uCtx.Courses.FirstOrDefault(c=>c.Id==Id);
            return course; 
        }
    }
}
