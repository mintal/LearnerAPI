using LearnerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnerAPI.Contexts
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> context) : base(context)
        {
        }

        public DbSet<Student> Students { get; protected set; }
        public DbSet<Study> Studies { get; protected set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(u => u.StudentNumber)
                .IsUnique();
            //checks if student number is unique
        }
    }
}