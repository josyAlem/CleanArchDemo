using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Interfaces
{
    public interface ICourseRepository
    {
        public List<Course> GetAll();
        public Course GetById(int id);
        public Course Add(Course course);
        public Course Update(Course course);
        public void Remove(int id);
    }
}
