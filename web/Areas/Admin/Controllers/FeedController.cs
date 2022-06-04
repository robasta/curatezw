using System.Threading.Tasks;
using Curate.Data.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FeedController : Controller
    {
        private readonly IRssFeedAdminService _feedAdminService;

        public FeedController(IRssFeedAdminService feedAdminService)
        {
            _feedAdminService = feedAdminService;
        }

        public async Task<IActionResult> Index()
        {
            var categorizedFeeds = _feedAdminService.GetAllCategorizedFeeds();
            return View(categorizedFeeds);
        }
        public async Task<IActionResult> EditFeed(int id)
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
        public async Task<IActionResult> EditFeedArticle(int id)
        {
            var feedArticle = _feedAdminService.GetFeedArticle(id);
            /*
             * 1. Fetch details via Youtube API
             * 2. Open this view, with FeedArticle prepopulated
             * 3. Have a preview pane/dialog
             * 4. Add Categorie and Tags
             * 5. Preview Item & Schedule to homepage ***
             * */
            return View(feedArticle);
        }

        [Produces("application/json")]
        public  IActionResult GetOneFeed(int feedId)
        {
            var feed =  _feedAdminService.GetFeed(feedId);
            return Ok(feed);
        }

        public async Task<IActionResult> ScanAll()
        {
            var result = await _feedAdminService.ScanAllRssFeeds();
            return View(result);
        }

        public async Task<IActionResult> ScanOne(int feedId)
        {
            //TODO: fetch feed from db
           var result =  await _feedAdminService.ScanOneRssFeed(feedId);
            return View(result);
        }

        public async Task<IActionResult> LoadOpml()
        {
            var result = await _feedAdminService.LoadOpmlFile("feedly.opml", true);
            return View(result);
        }


    }
}
