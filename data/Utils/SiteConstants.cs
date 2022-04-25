namespace Curate.Data.Utils
{
    public static class SiteConstants
    {
        public static string NyamboBaseUrl = "https://curate.co.zw/nyambo";

        public static class Css
        {
            public const string LoginProviderCssClass = "CssClass";

            public const string LoginProviderButtonCss = "ButtonCssClass";
        }


        public static class RouteNames
        {
            public const string Tags = "tags";
            public const string Tag = "tag";
            public const string UserLegacy = "user";
            public const string CheroLegacy = "cheroLegacy";
            public const string Chero = "chero";
            public const string Nyambo = "nyambo";
            public const string Post = "post";
            public const string NyamboHome = "nyambohome";
            public const string Contact = "contact";
            public const string Default = "default";
            public const string Sitemap = "sitemap";

        }

        public static class RouteTemplates
        {
            public const string NyamboDetail = "/{0}/{1}";
            public const string TagDetail = "/tag/{0}/{1}";
        }
    }
}
