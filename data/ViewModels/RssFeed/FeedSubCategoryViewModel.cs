using System.Collections.Generic;

namespace Curate.Data.ViewModels.RssFeed
{
    public class FeedSubCategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public IEnumerable<FeedViewModel> Feeds { get; set; }

        public FeedCategoryViewModel ParentCategory { get; set; }
    }
}