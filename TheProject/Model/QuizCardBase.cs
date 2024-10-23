using Microsoft.AspNetCore.Components;

namespace TheProject.Model
{
    public class QuizCardBase : ComponentBase
    {
        public List<Questions> Questions { get; set; } = new List<Questions>();
        protected int questionIndex = 0; 
        protected int score = 0; 

        protected override Task OnInitializedAsync()
        {

            LoadQuestions();

            return base.OnInitializedAsync();
        }

        protected void OptionSelected(string option)
        {
            if (option == Questions[questionIndex].Answer ) 
            {
                score ++; 
            }

            questionIndex++; 

        }




        private void LoadQuestions()
        {
            Questions q1 = new Questions
            {

                Question = "Hi", 

                Topic = "Organic",

                Option = new List<string>() { "A", "B", "C", "D" },
                
                Answer = "A"
            };


            Questions q2 = new Questions
            {

                Question = "Hey",

                Topic = "Organic",

                Option = new List<string>() { "A", "B", "C", "D" },

                Answer = "B"
            };


            Questions q3 = new Questions
            {

                Question = "Yo",


                Topic = "Organic",

                Option = new List<string>() { "A", "B", "C", "D" },

                Answer = "C"
            };


            Questions q4 = new Questions
            {

                Question = "Hiya",


                Topic = "Organic",

                Option = new List<string>() { "A", "B", "C", "D" },

                Answer = "D"
            };

            Questions.AddRange(new List<Questions> { q1, q2, q3, q4 } );
        }
    }
}
