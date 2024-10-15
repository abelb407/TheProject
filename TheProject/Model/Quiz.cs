namespace TheProject.Model
{
    public class Quiz
    {

        public int Id { get; set; }

        public Topic Topic { get; set; }    

        public List<Questions> Questions { get; set; }


    }
}
