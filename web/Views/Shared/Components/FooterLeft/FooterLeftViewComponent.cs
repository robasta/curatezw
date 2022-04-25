using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Views.Shared.Components.FooterLeft
{
    public class FooterLeftViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}