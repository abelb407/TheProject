using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheProject.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TheProject.Context
{
    public class UserProvider
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;

        public UserProvider(DatabaseContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<User>> GetUsersAsync(string username)
        {

            return await _context.Users
            .Where(u => u.UserName.Contains(username)) 
            .ToListAsync();

        }

  
    }
}

