using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Views.Shared.Components.HeaderLeft
{
    public class HeaderLeftViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}