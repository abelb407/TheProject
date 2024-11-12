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

            new Questions { Question = "Which functional group makes an alcohol polar?", Topic = "Alcohols", Option = ["Hydroxyl", "Methyl", "Ethyl", "Propyl"], Answer = "Hydroxyl", Solution = "The hydroxyl group is polar due to the electronegativity of oxygen." },

            new Questions { Question = "What is formed when a primary alcohol undergoes complete oxidation?", Topic = "Alcohols", Option = ["Aldehyde", "Carboxylic acid", "Ketone", "Ether"], Answer = "Carboxylic acid", Solution = "Complete oxidation of a primary alcohol forms a carboxylic acid." },


            new Questions { Question = "What type of bonds are present in alkanes?", Topic = "Alkanes", Option = ["Only sigma bonds", "Only pi bonds", "Sigma and pi bonds", "Hydrogen bonds"], Answer = "Only sigma bonds", Solution = "Alkanes have only single (sigma) bonds between carbon atoms." },

new Questions { Question = "Which reaction type involves breaking C-H bonds in alkanes?", Topic = "Alkanes", Option = ["Combustion", "Hydration", "Halogenation", "Polymerization"], Answer = "Combustion", Solution = "Combustion reactions break C-H bonds in alkanes to form carbon dioxide and water." },

new Questions { Question = "Which process is used to separate different alkanes from crude oil?", Topic = "Alkanes", Option = ["Distillation", "Oxidation", "Hydrolysis", "Electrolysis"], Answer = "Distillation", Solution = "Distillation is used to separate alkanes based on their boiling points." },

new Questions { Question = "What is the general formula for alkenes?", Topic = "Alkenes", Option = ["CnH2n", "CnH2n+2", "CnH2n-2", "CnHn"], Answer = "CnH2n", Solution = "Alkenes follow the general formula CnH2n due to the presence of one double bond." },

new Questions { Question = "Which type of isomerism is common in alkenes?", Topic = "Alkenes", Option = ["Geometric", "Optical", "Structural", "Conformational"], Answer = "Geometric", Solution = "Geometric isomerism arises in alkenes due to restricted rotation around the double bond." },

new Questions { Question = "Which reagent can test for the presence of a double bond in alkenes?", Topic = "Alkenes", Option = ["Bromine water", "Potassium permanganate", "Sodium hydroxide", "Sulfuric acid"], Answer = "Bromine water", Solution = "Bromine water decolorizes in the presence of an alkene due to addition across the double bond." },

new Questions { Question = "What is the characteristic smell of amines?", Topic = "Amines", Option = ["Fishy", "Sweet", "Fruity", "Odorless"], Answer = "Fishy", Solution = "Amines typically have a fishy smell due to the presence of nitrogen." },

new Questions { Question = "Which type of amine has three organic groups attached to nitrogen?", Topic = "Amines", Option = ["Primary", "Secondary", "Tertiary", "Quaternary"], Answer = "Tertiary", Solution = "In tertiary amines, nitrogen is bonded to three organic groups." },

new Questions { Question = "What is the basicity trend of amines in water?", Topic = "Amines", Option = ["Primary > Secondary > Tertiary", "Tertiary > Secondary > Primary", "Primary = Secondary = Tertiary", "Primary < Secondary < Tertiary"], Answer = "Primary > Secondary > Tertiary", Solution = "The basicity of amines decreases with increasing alkyl substitution due to steric hindrance." },

new Questions { Question = "Which halogenoalkane is used in the preparation of Grignard reagents?", Topic = "Halogenoalkanes", Option = ["Chlorobutane", "Fluoroethane", "Iodoethane", "Methyl bromide"], Answer = "Iodoethane", Solution = "Iodoethane is often used in Grignard reagent synthesis due to its high reactivity." },

new Questions { Question = "What type of reaction do halogenoalkanes undergo with aqueous KOH?", Topic = "Halogenoalkanes", Option = ["Nucleophilic substitution", "Electrophilic addition", "Elimination", "Oxidation"], Answer = "Nucleophilic substitution", Solution = "Halogenoalkanes react with aqueous KOH in a nucleophilic substitution reaction, forming alcohols." },

new Questions { Question = "Which halogen is the most reactive in halogenoalkanes?", Topic = "Halogenoalkanes", Option = ["Fluorine", "Chlorine", "Bromine", "Iodine"], Answer = "Iodine", Solution = "Iodine is the most reactive due to the weakest C-I bond, making it easier to break." },

new Questions { Question = "What is formed when an aldehyde is oxidized?", Topic = "Aldehydes", Option = ["Ketone", "Carboxylic acid", "Alcohol", "Ether"], Answer = "Carboxylic acid", Solution = "Aldehydes can be oxidized to form carboxylic acids." },

new Questions { Question = "Which test can confirm the presence of an aldehyde?", Topic = "Aldehydes", Option = ["Tollens' test", "Benedict's test", "Lucas test", "Fehling's test"], Answer = "Tollens' test", Solution = "Tollens' test produces a silver mirror with aldehydes but not with ketones." },

new Questions { Question = "What is the common property of aldehydes?", Topic = "Aldehydes", Option = ["Presence of carbonyl group", "Presence of hydroxyl group", "Presence of carboxyl group", "Presence of amine group"], Answer = "Presence of carbonyl group", Solution = "Aldehydes contain a carbonyl group bonded to a hydrogen." },

new Questions { Question = "What is the main property of carboxylic acids?", Topic = "Carboxylic Acids", Option = ["They are acidic", "They are basic", "They are neutral", "They are amphoteric"], Answer = "They are acidic", Solution = "Carboxylic acids can donate protons, making them acidic." },

new Questions { Question = "What product forms when a carboxylic acid reacts with an alcohol?", Topic = "Carboxylic Acids", Option = ["Ester", "Ketone", "Ether", "Aldehyde"], Answer = "Ester", Solution = "Carboxylic acids react with alcohols to form esters in a condensation reaction." },

new Questions { Question = "What is formed when a carboxylic acid is reduced?", Topic = "Carboxylic Acids", Option = ["Aldehyde", "Alcohol", "Ketone", "Ether"], Answer = "Aldehyde", Solution = "Carboxylic acids are reduced to aldehydes before they can form alcohols." },

        };
        }


        //Aldehydes & Ketones
        //Carboxylic Acids


    }
}
