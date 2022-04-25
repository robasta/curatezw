using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Views.Shared.Components.AdminHeader
{
    public class AdminHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}