using Curate.Data.Services.Interfaces;
using Curate.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Details(int id, string slug)
        {
            var video = _videoService.GetVideo(id);
            if (video == null)
            {
                return StatusCode(404);
            }
           // ViewBag.Title = video.Title;
            return View(video);
        }

        public IActionResult Playlist(int id, string slug)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Channels()
        {
            var viewModel = new TopicViewModel();
            ViewBag.Title = viewModel.Title;
            return View(viewModel);
        }
    }
}
