using System.Collections.Generic;
using Curate.Data.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;

namespace Curate.Web.ViewModels.RoleViewModels
{
    public class EditRoleVm
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }
}
