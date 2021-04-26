using CleanArch.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Interfaces
{
  public  interface ICourseService
    {
        public CourseDTO GetCourse();
    }
}
