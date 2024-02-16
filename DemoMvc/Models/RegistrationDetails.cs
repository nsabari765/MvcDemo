using Microsoft.AspNetCore.Identity;

namespace DemoMvc.Models
{
    public class RegistrationDetails : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; } 
    }
}
