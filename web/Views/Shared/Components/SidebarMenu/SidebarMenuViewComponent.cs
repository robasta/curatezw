using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Views.Shared.Components.SidebarMenu
{
    public class SidebarMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}