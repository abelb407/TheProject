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
            // Admin and User roles 
            if (!_context.Users.Any()) 
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));

                await _roleManager.CreateAsync(new IdentityRole("User"));
         

            }

            // If there are no quesitons, fetch them and then order them 
            if (!_context.Questions.Any())
            {
                var questions = GetQuestions();
                _context.Questions.AddRange(questions);
                await _context.SaveChangesAsync();
            }

        }
        // Method which retrieves the questions from the database     
        private List<Questions> GetQuestions()
        {
            return new List<Questions>
        {
            new Questions { Question = "Which group is always found in an alcohol?", Topic = "Alcohols", Option = ["Hydroxyl", "Carbonyl", "Nitrile", "Phosphate"], Answer = "Hydroxyl", Solution = "Alcohols are defined by a hydroxy group" },
            new Questions { Question = "Which one is organic?", Topic = "Alkanes", Option = ["Tin", "Carbon", "Lead", "Platinum"], Answer = "Carbon",                    Solution = "Organic chemistry revolves around carbon" },
            new Questions { Question = "Who's the electrophile?", Topic = "Alkenes", Option = ["Ammonia, NH3", "Hydroxide Ion, OH", "Hydronium Ion, H30", "Cyanide Ion, CN "], Answer = "Hydronium Ion, H30", Solution = "One oxygen with three bonds leads to a net positive charge" },
            new Questions { Question = "Which one is always in an amine?", Topic = "Amines", Option = ["TNT", "Nitrogen", "Propanone", "Sulfur"], Answer = "Nitrogen",    Solution = "The amine functional group is NH2" },
            new Questions { Question = "Which one is the halogen?", Topic = "Halogenoalkanes", Option = ["Strontium", "Astantine", "Selenium", "Rubidium"], Answer = "Astantine", Solution = "The halogens are in Group 7, as is Astantine."},
            new Questions { Question = "What is the catalyst for the oxidation of alcohols?", Topic = "Aldehydes and Ketones", Option = ["Acidified Chromium Permanganate", "Alcoholic Sodium Hydroxide", "Acidified Potassium Dichromate", "Milk"], Answer = "Acidified Potassium Dichromate", Solution = "Acidified Potassium Dichromate contains [ Cr2O7 ]2- ions which are reduced to oxidise the alcohol. Acidic conditions allow water to be formed as a result instead of unstable oxygen compounds" },
            new Questions { Question = "What is a practial application of an ester?", Topic = "Carboxylic Acids and Esters", Option = ["Gas chamber execution", "Violent reducing agent", "Bleaching", "Perfumes"], Answer = "Perfumes", Solution = "Esters tend to smell nice, and they are soluble in ethanol which is used in spray perfumes" },
        };
        }


        //Aldehydes & Ketones
        //Carboxylic Acids


    }
}
