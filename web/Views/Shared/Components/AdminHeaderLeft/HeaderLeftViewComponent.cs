using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Views.Shared.Components.AdminHeaderLeft
{
    public class AdminHeaderLeftViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}