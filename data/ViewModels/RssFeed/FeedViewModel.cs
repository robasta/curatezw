using System;
using System.Collections.Generic;

namespace Curate.Data.ViewModels.RssFeed
{
    public class FeedViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Blurb { get; set; }
        public string WebsiteUrl { get; set; }
        public string Slug { get; set; }

        public bool Blocked { get; set; }
        public string BlockedReason { get; set; }
        public DateTime? LastUpdated { get; set; }
        public FeedCategoryViewModel Category { get; set; }
        public FeedSubCategoryViewModel SubCategory { get; set; }
        public List<FeedArticleViewModel> Articles { get; set; }
    }
}
