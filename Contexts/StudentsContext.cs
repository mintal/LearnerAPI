using Learner.Models;
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
    }
}