using Curate.Data.Models;
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
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public IActionResult Details(int id, string slug)
        {
            var video = _videoService.GetVideo(id);
            if (video == null)
            {
                return StatusCode(404);
            }
            return View(video);
        }

        [HttpGet]
        public IActionResult Playlist(int id, string slug)
        {
            var playlist = _videoService.GetPlaylist(id);
            if (playlist == null)
            {
                return StatusCode(404);
            }
            return View(playlist);
        }

        [HttpGet]
        public IActionResult Channels()
        {
            var channels = _videoService.GetAllChannels();
            return View(channels);
        }

        [HttpGet]
        public IActionResult CreateChannel()
        {
            var channel = new VideoChannel();
            return View(channel);
        }

        [HttpPost]
        public IActionResult CreateChannel(VideoChannel channel)
        {
            _videoService.CreateChannel(channel);
            return View(channel);
        }

    }
}
