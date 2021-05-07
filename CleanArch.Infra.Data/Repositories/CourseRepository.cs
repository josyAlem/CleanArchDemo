using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<Course> GetAll() {
           return _uCtx.Courses.ToList(); 
        }
        public Course GetById(int id) { 
           return _uCtx.Courses.FirstOrDefault(c=>c.Id==id);
        }

        public Course Add(Course course)
        {
            throw new  NotImplementedException();
        }

        public Course Update(Course course)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
