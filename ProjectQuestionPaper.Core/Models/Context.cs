using Microsoft.EntityFrameworkCore;

namespace ProjectQuestionPaper.Core.Models
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<File> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Database=ProjectQuestionPaper;Trusted_Connection=True;Connect Timeout=300");
        }
    }
}
