using CleanArch.Application.DTO;

namespace CleanArch.Application.Interfaces
{
    public  interface ICourseService
    {
        public CourseDTO GetCourseById(int Id);
        public CourseDTO AddCourse(CourseDTO course);
        public CourseDTO UpdateCourse(CourseDTO course);
        public void RemoveCourse(int id);
    }
}
