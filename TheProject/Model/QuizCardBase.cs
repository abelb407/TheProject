using Microsoft.AspNetCore.Components;

namespace TheProject.Model
{
    public class QuizCardBase : ComponentBase
    {
        public List<Questions> Questions { get; set; } = new List<Questions>();
        public int questionIndex = 0; 
        public int score = 0; 

        protected override Task OnInitializedAsync()
        {

            LoadQuestions();

            return base.OnInitializedAsync();
        }

        protected void OptionSelected(string option)
        {
            if (option == Questions[questionIndex].Answer ) 
            {
                score++; 
            }

            questionIndex++; 

        }




        private void LoadQuestions()
        {
            Questions q1 = new Questions
            {

                Question = "What is alcohol?", 

                Topic = "Organic",

                Option = new List<string>() { "Hydroxy", "Carbonyl", "Nitrile", "Phosphate" },
                
                Answer = "Hydroxy"
            };


            Questions q2 = new Questions
            {

                Question = "Which one is organic?",

                Topic = "Organic",

                Option = new List<string>() { "Tin", "Carbon", "Lead", "Platinum" },

                Answer = "Carbon"
            };


            Questions q3 = new Questions
            {

                Question = "Who's the electrophile?",


                Topic = "Organic",

                Option = new List<string>() { "Ammonia", "Hydroxide Ion", "Hydronium Ion", "Cyanide Ion" },

                Answer = "Hydronium Ion"
            };


            Questions q4 = new Questions
            {

                Question = "Which one smells like rotten eggs?",


                Topic = "Organic",

                Option = new List<string>() { "Chlorine", "Dog", "Propanone", "Hydrogen Sulfide" },

                Answer = "Hydrogen Sulfide"
            };

            Questions.AddRange(new List<Questions> { q1, q2, q3, q4 } );
        }
    }
}
