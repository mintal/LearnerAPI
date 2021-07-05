using LearnerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnerAPI.Contexts
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> context) : base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasAlternateKey(s => s.StudentNumber);
        }

        public DbSet<Student> Students { get; protected set; }
        public DbSet<Study> Studies { get; protected set; }
    }
}