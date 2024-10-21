using Microsoft.AspNetCore.Identity;

namespace TheProject.Model
{
    public class User : IdentityUser
    {
        public int Points { get; set; }
        public int totalQuestions { get; set; }
        public string School { get; set; }  
        public string Gender { get; set; }  

    }
}


