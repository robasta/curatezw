using Curate.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICollectionService _collectionService;

        public HomeController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        public IActionResult Index()
        {
            var collections = _collectionService.GetCollections();
            return View(collections);
        }
    }
}
