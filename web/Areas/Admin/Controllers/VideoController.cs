using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;
using Curate.Data.Services.Interfaces;
using Curate.Data.Utils;
using Curate.Data.ViewModels.Article;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;
        private readonly ITagService _tagService;
        public VideoController(IVideoService videoService, ITagService tagService)
        {
            _videoService = videoService;
            _tagService = tagService;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var articleViewModel = _videoService.GetVideo(id);
            articleViewModel.SetTagList();
            return View(articleViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ArticleViewModel articleViewModel)
        {
            _videoService.SaveVideo(articleViewModel);
            articleViewModel = _videoService.GetVideo(articleViewModel.Id);
            return RedirectToAction("Edit", new {id=articleViewModel.Id});
        }

    }
}
