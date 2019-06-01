using EntityFrameworkExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkExample
{
  public class ApplicationContext : DbContext
  {
    public DbSet<ClassRoom> ClassRoom { get; set; }

    public DbSet<Teacher> Teacher { get; set; }

    public DbSet<Student> Student { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=school.db");
    }
  }
}