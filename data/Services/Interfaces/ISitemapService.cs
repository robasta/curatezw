using System.Collections.Generic;
using System.Threading.Tasks;
using Curate.Data.ViewModels.Sitemap;

namespace Curate.Data.Services.Interfaces
{
    public interface ISitemapService
    {
        Task<List<SitemapItem>> GetSitemapItems();
    }
}
