using Microsoft.AspNetCore.Identity;

namespace Curate.Data.ViewModels.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarURL { get; set; }
        public string DateRegistered { get; set; }
    }
}
