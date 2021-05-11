using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CleanArch.Infra.Data.Repositories
{
    public class CourseRepositoryDapper : ICourseRepository
    {
        private IDbConnection db;

        public CourseRepositoryDapper(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("CommanderConnection"));
        }
        public List<Course> GetAll() {
            var sql = "Select * from Courses";
            return db.Query<Course>(sql).ToList();


        }
        public Course GetById(int id)
        {
            var sql = "Select * from Courses where Id=@courseId";
            var result = db.Query<Course>(sql, new { @courseId = id }).SingleOrDefault();
            if(result==null)
                throw new Exception("Course Not Found");
            return result;

        }

        public Course Add(Course course)
        {
            var sql = "Insert into Courses(Name,Description) values(@name,@description);"
                 + "Select CAST(SCOPE_IDENTITY() as int);";
        
            var id = db.Query<int>(sql,
                new { @name = course.Name,
                @description = course.Description }).Single();
            course.Id = id;
            return course;
        }
        public Course Update(Course course)
        {
           
            var sql = "update Courses set Name=@name,Description=@description where Id=@courseId";

          int x=db.Execute(sql,
                new
                {
                    @courseId=course.Id,
                    @name = course.Name,
                    @description = course.Description
                });
            if(x==0)
                throw new Exception("Course Not Found");
            return course;
        }
        public void Remove(int id)
        {

            var sql = "Delete from Courses where Id=@courseId";
            int x = db.Execute(sql, new { @courseId = id });
            if (x == 0)
                throw new Exception("Course Not Found");
        }
    }
}
