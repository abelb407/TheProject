using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheProject.Model;

namespace TheProject.Context
{
    public class DatabaseSeeder
    {

        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
    
        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager )
        {
            _context = context; 
            _userManager = userManager;
            _roleManager = roleManager; 
        }

        public async Task Seed()
        {
            await _context.Database.MigrateAsync(); 

            if (!_context.Users.Any()) 
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));

                await _roleManager.CreateAsync(new IdentityRole("User"));

                var adminEmail = "abel@gmail.com";
                var adminPassword = "Eth123!";

                var admin = new User
                {
                    Email = adminEmail,
                    Points = 0, 
                    totalQuestions = 0, 
                    School = "Southfields Academy",
                    Gender = "Male", 
                };

         
                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");

            }


            if (!_context.Questions.Any())
            {
                var questions = GetQuestions();
                _context.Questions.AddRange(questions);
                await _context.SaveChangesAsync();
            }

        }
        private List<Questions> GetQuestions()
        {
            return new List<Questions>
    {
        new Questions { Question = "Which group is always found in an alcohol?", Topic = "Alcohols", Option = new List<string> { "Hydroxyl", "Carbonyl", "Nitrile", "Phosphate" }, Answer = "Hydroxyl" },
        new Questions { Question = "Which one is organic?", Topic = "Alkanes", Option = new List<string> { "Tin", "Carbon", "Lead", "Platinum" }, Answer = "Carbon" },
        new Questions { Question = "Who's the electrophile?", Topic = "Alkenes", Option = new List<string> { "Ammonia", "Hydroxide Ion", "Hydronium Ion", "Cyanide Ion" }, Answer = "Hydronium Ion" },
        new Questions { Question = "Which one is aminey?", Topic = "Amines", Option = new List<string> { "Bomb", "Nitrogen", "Propanone", "Sulfur" }, Answer = "Nitrogen" }
        };
        }


    }
}
