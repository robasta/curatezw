using System;
using System.Collections.Generic;
using Curate.Data.ViewModels.Article;
using Curate.Data.ViewModels.Category;

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
        public CategoryViewModel Category { get; set; }
        public SubCategoryViewModel SubCategory { get; set; }
        public List<ArticleViewModel> Articles { get; set; }
    }
}
