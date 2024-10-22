namespace TheProject.Model
{
    public class Questions
    {

        public int Id { get; set; }

        public string Question { get; set; } = string.Empty;  

        public string Topic { get; set; } = string.Empty;

        public IEnumerable<string> Options { get; set; } = new List<String>();

        public string Answer {  get; set; } = string.Empty;

    }
}
