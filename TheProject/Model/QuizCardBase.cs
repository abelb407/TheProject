using Microsoft.AspNetCore.Components;
using System.Security.AccessControl;

namespace TheProject.Model
{
    public class QuizCardBase : ComponentBase
    {
       
        public List<Questions> Questions { get; set; } = new List<Questions>();
        public int questionIndex = 0; 
        public int score = 0;

        protected void RestartQuiz()
        {
            score = 0;
            questionIndex = 0;
        }
        protected override Task OnInitializedAsync()
        {

            LoadQuestions();

            return base.OnInitializedAsync();
        }

        protected void OptionSelected(string option)
        {
            if (option == Questions[questionIndex].Answer ) 
            {
                //When an option is selected: increment score by 1 if answer is correct, then increment the index to load the next question
                score++; 
            }

            questionIndex++; 

        }




        private void LoadQuestions()
        {
            // Questions which are displayed in the quiz. 
            Questions q1 = new Questions
            {

                Question = "Which group is always found in an alcohol?", 

                Topic = "Alcohol",

                Option = new List<string>() { "Hydroxy", "Carbonyl", "Nitrile", "Phosphate" },
                
                Answer = "Hydroxy"
            };


            Questions q2 = new Questions
            {

                Question = "Which one is organic?",

                Topic = "General",

                Option = new List<string>() { "Tin", "Carbon", "Lead", "Platinum" },

                Answer = "Carbon"
            };


            Questions q3 = new Questions
            {

                Question = "Who's the electrophile?",


                Topic = "General",

                Option = new List<string>() { "Ammonia", "Hydroxide Ion", "Hydronium Ion", "Cyanide Ion" },

                Answer = "Hydronium Ion"
            };


            Questions q4 = new Questions
            {

                Question = "Which one smells like rotten eggs?",


                Topic = "General",

                Option = new List<string>() { "Chlorine", "Dog", "Propanone", "Hydrogen Sulfide" },

                Answer = "Hydrogen Sulfide"
            };

            // Code assigning numerical order to the questions, so incrementing moves between them 
            Questions.AddRange(new List<Questions> { q1, q2, q3, q4 } );
        }
    }
}
