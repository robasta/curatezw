using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Search(string q)
        {
            var tags = _tagService.Search(q);
            var jsonTags = tags.Select(tag => new JsonTag { Id = tag.Id, Name = tag.Title }).ToList();
            return Ok(jsonTags);
        }
    }
}
