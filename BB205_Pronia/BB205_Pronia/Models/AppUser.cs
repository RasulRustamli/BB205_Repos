using Microsoft.AspNetCore.Identity;

namespace BB205_Pronia.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsRemained { get; set; }

    }
}
