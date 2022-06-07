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
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var articleViewModel = _videoService.GetVideo(id);
            articleViewModel.SetTagList();
            articleViewModel.SetCollectionList();;
            return View(articleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ArticleViewModel articleViewModel)
        {
            await _videoService.SaveVideo(articleViewModel);
            articleViewModel = _videoService.GetVideo(articleViewModel.Id);
            return RedirectToAction("Edit", new {id=articleViewModel.Id});
        }

    }
}
