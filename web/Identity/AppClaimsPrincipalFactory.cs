using System.Security.Claims;
using System.Threading.Tasks;
using Curate.Data.ViewModels.Identity;
using Curate.Web.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Curate.Web.Identity
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public AppClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                new Claim(CustomClaimTypes.GivenName, user.FirstName),
                new Claim(CustomClaimTypes.Surname, user.LastName),
                new Claim(CustomClaimTypes.AvatarURL, user.AvatarURL),
                new Claim(CustomClaimTypes.DateRegistered, user.DateRegistered),
            });

            return principal;
        }
    }
}