namespace TheProject.Model
{
    public class Questions
    {
        public int Id { get; set; } 
        public string Question { get; set; }

        public string Topic { get; set; }

        public List<string> Option { get; set; }

        public string Answer { get; set; }

    }
}