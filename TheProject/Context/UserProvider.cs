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
            // Get all the users in the database who match the search parameter
            return await _context.Users
            .Where(u => u.UserName.Contains(username)) 
            .ToListAsync();

        }



        public async Task<List<User>> GetUsersOrderedByPointsAsync()
        {
            // Order the users in order of points, highest to lowest and return as a list
            return await _context.Users
                .OrderByDescending(u => u.Points)
                .ToListAsync();
        }

        public async Task<List<User>> GetUsersOrderedByQuestionsAsync()
        {
            // Order the users in order of questions, highest to lowest and return as a list
            return await _context.Users
                .OrderByDescending(u => u.totalQuestions)
                .ToListAsync();
        }


    }
}

