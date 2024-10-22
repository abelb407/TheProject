using Microsoft.AspNetCore.Components;

namespace TheProject.Model
{
    public class QuizCardBase : ComponentBase
    {
        public List<Questions> Questions { get; set; } = new List<Questions>();

        protected override Task OnInitializedAsync()
        {

            LoadQuestions();

            return base.OnInitializedAsync();
        }

        private void LoadQuestions()
        {
            Questions q1 = new Questions
            {

                Question = "eggs", 

                Topic = "Organic",

                Options = new List<string>() { "A", "B", "C", "D" },
                
                Answer = "A"
            };


            Questions q2 = new Questions
            {

                Question = "eggs",

                Topic = "Organic",

                Options = new List<string>() { "A", "B", "C", "D" },

                Answer = "B"
            };


            Questions q3 = new Questions
            {

                Question = "eggs",


                Topic = "Organic",

                Options = new List<string>() { "A", "B", "C", "D" },

                Answer = "C"
            };


            Questions q4 = new Questions
            {

                Question = "eggs",


                Topic = "Organic",

                Options = new List<string>() { "A", "B", "C", "D" },

                Answer = "D"
            };

            Questions.AddRange(new List<Questions> { q1, q2, q3, q4 } );
        }
    }
}
