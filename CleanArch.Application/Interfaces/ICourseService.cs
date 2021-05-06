using CleanArch.Application.DTO;

namespace CleanArch.Application.Interfaces
{
    public  interface ICourseService
    {
        public CourseDTO GetCourseById(int Id);
    }
}
