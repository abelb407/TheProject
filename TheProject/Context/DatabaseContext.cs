using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheProject.Model;

namespace TheProject.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {

        
        private IWebHostEnvironment _environment;

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Leaderboard> Leaderboards { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IWebHostEnvironment environment) : base(options)
        {
            _environment = environment;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {

            var folder = Path.Combine(_environment.WebRootPath, "database"); 
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            optionbuilder.UseSqlite($"Data Source={folder}/chemistry.db");
        }
    }
 }
