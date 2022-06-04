using System.Threading.Tasks;
using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;
using Curate.Data.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;
        private readonly IRssFeedAdminService _feedAdminService;
        public VideoController(IVideoService videoService, IRssFeedAdminService feedAdminService)
        {
            _videoService = videoService;
            _feedAdminService = feedAdminService;
        }

        [HttpGet]
        public async Task<IActionResult> EditVideo(int id)
        {
            var article = _feedAdminService.GetFeedArticle(id);
            
            /*
             * 4. Add Categorie and Tags
             * 5. Preview Item & Add to Collection***
             * */
            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> EditVideo(Article article)
        {
          
            return View(article);
        }

    }
}
