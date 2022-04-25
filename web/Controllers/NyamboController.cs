using System.Threading.Tasks;
using Curate.Data.Services.Interfaces;
using Curate.Data.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Curate.Web.Controllers
{
    public class NyamboController : Controller
    {
        private readonly INyamboService _nyamboService;
        private readonly ITagService _tagService;
        private readonly IConfiguration _configuration;

        public NyamboController(INyamboService nyamboService, IConfiguration configuration, ITagService tagService)
        {
            _nyamboService = nyamboService;
            _configuration = configuration;
            _tagService = tagService;
        }

        public async Task<ActionResult> Index(int page = 1)
        {
            var pageSize = _configuration.GetValue<int>("PageSize");
            var posts = await _nyamboService.GetPagedNyambo(page, pageSize);
            var postCount = await _nyamboService.GetNyamboCount();
            var viewModel = new NyamboListViewModel(posts, page, pageSize, postCount);
            return View(viewModel);
        }

        public async Task<ActionResult> Details(string id, string slug)
        {
            var nyambo = await _nyamboService.GetNyamboById(id);
            if (nyambo != null)
            {
                var viewModel = new NyamboViewModel(nyambo);
                ViewBag.Title = nyambo.Title + " - Nyambo";
                return View(viewModel);
            }

            System.Diagnostics.Trace.TraceError($"Nyambo not found id:{id}, slug:{slug}, url{Request.GetDisplayUrl()}");
            return new NotFoundResult();
        }

        public async Task<ActionResult> TagDetails(int id, string slug)
        {
            var tag = await _tagService.GetTag(id, "TagPosts.Post");
            if (tag != null)
            {
                var viewModel = new TagViewModel(tag);
                ViewBag.Title = tag.Title;
                return View("TagDetails", viewModel);
            }

            System.Diagnostics.Trace.TraceError($"Nyambo not found id:{id}, slug:{slug}, url{Request.GetDisplayUrl()}");
            return new NotFoundResult();
        }


        public ActionResult Chero()
        {
            ViewBag.SeoTitle = "Random Nyambo";
            ViewBag.Title = "Random Nyambo";
            ViewBag.SeoDescription =
                "Pese pauno svika pa peji rino, unorohwa nenyambo yakasiyana neyawamboona. Get a random joke everytime you land on this page.";
            return View("Details",_nyamboService.GetRandomNyambo());
        }
    }
}