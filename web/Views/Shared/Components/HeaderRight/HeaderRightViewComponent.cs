using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Views.Shared.Components.HeaderRight
{
    public class HeaderRightViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}