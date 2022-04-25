using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Views.Shared.Components.SidebarBrand
{
    public class SidebarBrandViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}