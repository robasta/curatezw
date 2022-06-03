using System;
using System.Collections.Generic;
using System.Globalization;

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
        public  int FeedId { get; set; }
        public DateTime? LastFeaturedDate { get; set; }
        public bool HasBeenFeatured => LastFeaturedDate != null;
        public string FormattedPublishDate
        {
            get
            {
                if (PublishDate == null)
                {
                    return string.Empty;
                }
                return ((DateTime)PublishDate).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            }
        }
        public string FormattedLastFeaturedDate
        {
            get
            {
                if (LastFeaturedDate == null)
                {
                    return string.Empty;
                }
                return ((DateTime)LastFeaturedDate).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            }
        }
    }
}