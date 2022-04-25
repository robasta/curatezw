using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Views.Shared.Components.ControlSidebar
{
    public class ControlSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}