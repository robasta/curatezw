using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Views.Shared.Components.HeaderSearchForm
{
    public class HeaderSearchFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}