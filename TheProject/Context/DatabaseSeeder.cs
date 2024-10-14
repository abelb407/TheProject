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
                await _roleManager.CreateAsync(new IdentityRole("Moderator"));
                await _roleManager.CreateAsync(new IdentityRole("Teacher"));
                await _roleManager.CreateAsync(new IdentityRole("Student"));

                var modName = "abel";
                var modPassword = "Tantalum123";

                var moderator = new User
                {
                    Name = modName,
                    Points = 0, 
                    totalQuestions = 0, 
                    School = "SouthfieldsAcademy",
                    Gender = "Male", 
                };

                await _userManager.CreateAsync(moderator, modPassword);
                await _userManager.AddToRoleAsync(moderator, "Moderator");

            }
        }


    }
}
