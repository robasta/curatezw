using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Curate.Data.Services.Interfaces;
using Curate.Data.ViewModels.Json;

namespace Curate.Web.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionService _collectionService;

        public CollectionController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [Produces("application/json")]
        public IActionResult Search(string q, bool titlesOnly=false)
        {
            var collections = _collectionService.Search(q.ToLower());
            if (titlesOnly)
            {
                return Ok(collections.Select(c => c.Title).ToList());
            }
            return Ok(collections.Select(c => new JsonTag { Id = c.Id, Name = c.Title }).ToList());
        }
    }
}
