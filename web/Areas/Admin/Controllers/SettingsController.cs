using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToPage("/Settings/Profile");
        }

        public IActionResult TwoFactorAuth()
        {
            return RedirectToPage("/Settings/TwoFactorAuth/Config");
        }
    }
}