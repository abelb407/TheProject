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
                
                var Users = GetUsers();

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

        private List<User> GetUsers()
        {
            return new List<User>
            {



            };
        }

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

new Questions { Question = "What is the molecular shape of methane?", Topic = "Alkanes", Option = ["Tetrahedral", "Linear", "Trigonal planar", "Bent"], Answer = "Tetrahedral", Solution = "Methane (CH4) has a tetrahedral molecular geometry due to the four bonding pairs of electrons around the central carbon atom." },

new Questions { Question = "What is the type of bonding present in alkenes?", Topic = "Alkenes", Option = ["Ionic bonding", "Covalent bonding", "Metallic bonding", "Hydrogen bonding"], Answer = "Covalent bonding", Solution = "Alkenes contain covalent bonds between carbon atoms, with a double bond that includes one sigma and one pi bond." },

new Questions { Question = "Which type of polymer is formed from alkenes?", Topic = "Alkenes", Option = ["Addition polymer", "Condensation polymer", "Protein polymer", "Carbohydrate polymer"], Answer = "Addition polymer", Solution = "Alkenes undergo addition polymerization, where the double bonds open up to form long-chain polymers." },

new Questions { Question = "What is a characteristic feature of a primary amine?", Topic = "Amines", Option = ["One carbon attached to nitrogen", "Two carbons attached to nitrogen", "Three carbons attached to nitrogen", "No carbon attached to nitrogen"], Answer = "One carbon attached to nitrogen", Solution = "A primary amine has one carbon atom bonded to the nitrogen atom, along with two hydrogen atoms." },

new Questions { Question = "What type of bond is formed between nitrogen and hydrogen in amines?", Topic = "Amines", Option = ["Ionic bond", "Covalent bond", "Hydrogen bond", "Metallic bond"], Answer = "Covalent bond", Solution = "Amines have covalent bonds between nitrogen and hydrogen atoms, where nitrogen shares electrons with hydrogen." },

new Questions { Question = "What is the most common use of amines?", Topic = "Amines", Option = ["Synthesis of dyes", "Formation of polymers", "Agricultural pesticides", "Food preservation"], Answer = "Synthesis of dyes", Solution = "Amines are commonly used in the synthesis of dyes, as they are reactive and can form colored compounds." },

new Questions { Question = "Which functional group is present in aldehydes?", Topic = "Aldehydes", Option = ["Carboxyl", "Amino", "Carbonyl", "Hydroxyl"], Answer = "Carbonyl", Solution = "Aldehydes contain a carbonyl group (C=O) attached to a hydrogen atom." },

new Questions { Question = "What is the effect of aldehydes on Tollens' reagent?", Topic = "Aldehydes", Option = ["It reduces it to silver", "It turns it blue", "It produces a red precipitate", "It reacts with no change"], Answer = "It reduces it to silver", Solution = "Aldehydes reduce Tollens' reagent to silver metal, forming a characteristic silver mirror." },

new Questions { Question = "What is a major use of carboxylic acids?", Topic = "Carboxylic Acids", Option = ["As solvents", "As food additives", "As disinfectants", "As antioxidants"], Answer = "As food additives", Solution = "Carboxylic acids, like acetic acid, are commonly used as food additives, especially as preservatives and flavor enhancers." },

new Questions { Question = "What happens when a carboxylic acid is neutralized?", Topic = "Carboxylic Acids", Option = ["Forms a salt and water", "Forms an alcohol", "Forms a ketone", "Forms an ester"], Answer = "Forms a salt and water", Solution = "When a carboxylic acid reacts with a base, it forms a salt and water in a neutralization reaction." },

new Questions { Question = "Which is a common method of reducing carboxylic acids?", Topic = "Carboxylic Acids", Option = ["Using hydrogen and a catalyst", "Using sodium hydroxide", "Using heat alone", "Using ultraviolet light"], Answer = "Using hydrogen and a catalyst", Solution = "Carboxylic acids can be reduced to alcohols by reacting with hydrogen in the presence of a catalyst like palladium." },

new Questions { Question = "What type of reaction do carboxylic acids undergo with alcohols?", Topic = "Carboxylic Acids", Option = ["Esterification", "Hydrogenation", "Nitration", "Polymerization"], Answer = "Esterification", Solution = "Carboxylic acids react with alcohols in a condensation reaction to form esters, known as esterification." },

new Questions { Question = "What is the effect of carboxylic acids on pH?", Topic = "Carboxylic Acids", Option = ["Increase pH", "Decrease pH", "No effect on pH", "Neutralize pH"], Answer = "Decrease pH", Solution = "Carboxylic acids donate protons (H+ ions) in solution, lowering the pH and making the solution acidic." }

        };
        }


        //Aldehydes & Ketones
        //Carboxylic Acids


    }
}
