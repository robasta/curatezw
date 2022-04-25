using System.Collections.Generic;
using System.Threading.Tasks;
using Curate.Data.ViewModels.RssFeed;

namespace Curate.Data.Services.Interfaces
{
    public interface IRssFeedAdminService
    {
        Task<bool> LoadOpmlFile(string filename, bool scan);
        public Task<bool> ScanAllRssFeeds();
        public Task<bool> ScanOneRssFeed(int feedId);
        public FeedViewModel GetFeed(int feedId);
        public List<FeedCategoryViewModel> GetAllCategorizedFeeds();
    }
}