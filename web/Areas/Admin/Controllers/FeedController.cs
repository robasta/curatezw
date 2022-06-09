using System.Threading.Tasks;
using Curate.Data.Models;
using Curate.Data.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FeedController : Controller
    {
        private readonly IRssFeedService _feedService;

        public FeedController(IRssFeedService feedService)
        {
            _feedService = feedService;
        }

        public async Task<IActionResult> Index()
        {
            var categorizedFeeds = _feedService.GetAllCategorizedFeeds();
            return View(categorizedFeeds);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new RssFeed());
        }

        [HttpPost]
        public async Task<IActionResult> Create(RssFeed feed)
        {
            await _feedService.AddFeed(feed);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            /*var feedArticle = _feedAdminService.GetFeedArticle(id);
            
             * 1. Fetch details via Youtube API
             * 2. Open this view, with FeedArticle prepopulated
             * 3. Have a preview pane/dialog
             * 4. Add Categorie and Tags
             * 5. Preview Item & Schedule to homepage ***
             * */
            return View();
        }
       

        [Produces("application/json")]
        public  IActionResult GetOneFeed(int feedId)
        {
            var feed =  _feedService.GetFeed(feedId);
            return Ok(feed);
        }

        public async Task<IActionResult> ScanAll()
        {
            var result = await _feedService.ScanAllRssFeeds();
            return View(result);
        }

        public async Task<IActionResult> ScanOne(int feedId)
        {
            //TODO: fetch feed from db
           var result =  await _feedService.ScanOneRssFeed(feedId);
            return View(result);
        }

        public async Task<IActionResult> LoadOpml()
        {
            var result = await _feedService.LoadOpmlFile("feedly.opml", true);
            return View(result);
        }


    }
}
