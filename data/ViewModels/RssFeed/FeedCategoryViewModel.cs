using System.Collections.Generic;

namespace Curate.Data.ViewModels.RssFeed
{
    public class FeedCategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }

        public IEnumerable<FeedSubCategoryViewModel> SubCategories { get; set; }
    }
}