using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Context
{
    public  class UniversityDbContext:DbContext
    {
        public UniversityDbContext(DbContextOptions opt) : base(opt)
        {

        }
        public DbSet<Course> Courses { get; set; }
    }
}
