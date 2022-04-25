using System;
using System.Collections.Generic;

namespace Curate.Data.ViewModels.RssFeed
{
    public class FeedArticleViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }

        public bool IsProcessed { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }

    }
}