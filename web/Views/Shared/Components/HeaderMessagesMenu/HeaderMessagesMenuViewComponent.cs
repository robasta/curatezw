using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Views.Shared.Components.HeaderMessagesMenu
{
    public class HeaderMessagesMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}