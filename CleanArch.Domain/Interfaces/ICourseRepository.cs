using CleanArch.Domain.Models;

namespace CleanArch.Domain.Interfaces
{
    public interface ICourseRepository
    {
        public Course GetCourseById(int Id);
    }
}
