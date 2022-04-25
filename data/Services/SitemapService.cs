using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Curate.Data.Services.Interfaces;
using Curate.Data.ViewModels.Sitemap;

namespace Curate.Data.Services
{
    public class SitemapService:ISitemapService
    {
        public async Task<List<SitemapItem>> GetSitemapItems()
        {
            throw new NotImplementedException();
        }
    }
}
