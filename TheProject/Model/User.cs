using Microsoft.AspNetCore.Identity;

namespace TheProject.Model
{
    public class User : IdentityUser
    {

        public int Id { get; set; }

        public string Name { get; set; }    

        public int Points { get; set; }

        public int totalQuestions { get; set; }

        public string School { get; set; }  

        public string Gender { get; set; }  


    }
}
