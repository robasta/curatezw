﻿using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Views.Shared.Components.FooterRight
{
    public class FooterRightViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}