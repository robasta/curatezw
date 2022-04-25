using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
