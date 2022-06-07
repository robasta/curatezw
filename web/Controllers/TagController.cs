using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Curate.Data.Services.Interfaces;
using Curate.Data.ViewModels.Json;

namespace Curate.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [Produces("application/json")]
        public IActionResult Search(string q, bool titlesOnly=false)
        {
            var tags = _tagService.Search(q.ToLower());
            if (titlesOnly)
            {
                return Ok(tags.Select(tag => tag.Title).ToList());
            }
            return Ok(tags.Select(tag => new JsonTag { Id = tag.Id, Name = tag.Title }).ToList());
        }
    }
}
