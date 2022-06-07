using System.Threading.Tasks;
using Curate.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Curate.Data.Services.Interfaces;

namespace Curate.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CollectionController : Controller
    {
        private readonly ICollectionService _collectionService;

        public CollectionController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        public IActionResult Index()
        {
            var collections = _collectionService.GetCollections();
            return View(collections);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var collection = new Collection();
            return View(collection);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Collection collection)
        {
            await _collectionService.InsertCollection(collection);
            return RedirectToAction("Index");
        }

    }
}
