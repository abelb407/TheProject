using Microsoft.EntityFrameworkCore;
using TheProject.Model;

namespace TheProject.Context
{
    public class QuestionProvider
    {
        private readonly DatabaseContext _context;

        public QuestionProvider(DatabaseContext Context)
        {
            _context = Context; 
        }

        // Method which returns the list of questions to the quiz page from the seeder
        public async Task<List<Questions>> GetQuestionsAsync()
        {
            return await _context.Questions.ToListAsync(); 
        }

    }
}
