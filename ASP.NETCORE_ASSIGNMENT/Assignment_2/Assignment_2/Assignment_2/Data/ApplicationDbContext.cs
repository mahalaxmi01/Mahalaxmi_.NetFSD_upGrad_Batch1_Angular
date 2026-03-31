using Microsoft.EntityFrameworkCore;
using Assignment_2.Models;

namespace Assignment_2.Data 
{
    public class ApplicationDbContext : DbContext
    {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
}
}
