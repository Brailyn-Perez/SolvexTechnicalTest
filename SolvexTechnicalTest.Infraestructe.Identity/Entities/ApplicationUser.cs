using Microsoft.AspNetCore.Identity;

namespace SolvexTechnicalTest.Infraestructe.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
