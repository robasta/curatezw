using Curate.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Curate.Web.Controllers
{
    [Authorize(Roles = "SuperAdmins")]
    public class UserLogsController : Controller
    {
        private readonly curatedbContext _context;

        public UserLogsController(curatedbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            return View(_context.UserAuditEvents.ToList());
        }
    }
}
