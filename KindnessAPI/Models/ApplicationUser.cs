using Microsoft.AspNetCore.Identity;

namespace KindnessAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }    
    }
}
