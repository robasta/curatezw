using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Curate.Data.ViewModels.Sitemap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curate.Web.Utils
{
    public class XmlSitemapResult : ActionResult
    {
        private readonly IEnumerable<SitemapItem> _items;
        readonly XNamespace _ns = @"http://www.sitemaps.org/schemas/sitemap/0.9";

        public XmlSitemapResult(IEnumerable<SitemapItem> items)
        {
            _items = items;
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var sitemap = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(_ns + "urlset",
                    from item in _items
                    select CreateItemElement(item)
                )
            );

            context.HttpContext.Response.ContentType = "application/rss+xml";
            await context.HttpContext.Response.WriteAsync(sitemap.Declaration + sitemap.ToString());
        }


        private XElement CreateItemElement(SitemapItem item)
        {
            var itemElement = new XElement(_ns + "url", new XElement(_ns + "loc", item.Url.ToLower()));

            if(item.LastModified.HasValue)
                itemElement.Add(new XElement(_ns + "lastmod", item.LastModified.Value.ToString("yyyy-MM-dd")));

            if(item.ChangeFrequency.HasValue)
                itemElement.Add(new XElement(_ns + "changefreq", item.ChangeFrequency.Value.ToString().ToLower()));

            if(item.Priority.HasValue)
                itemElement.Add(new XElement(_ns + "priority", item.Priority.Value.ToString(CultureInfo.InvariantCulture)));

            return itemElement;        
        }
    }
}
