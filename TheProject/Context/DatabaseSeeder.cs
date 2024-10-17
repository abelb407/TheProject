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
                var adminPassword = "Website123!";

                var admin = new User
                {
                    Email = adminEmail,
                    Points = 0, 
                    totalQuestions = 0, 
                    School = "SouthfieldsAcademy",
                    Gender = "Male", 
                };

         
                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");

            }
        }


    }
}
