using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class RssFeed
    {
        public RssFeed()
        {
            RssFeedArticles = new HashSet<RssFeedArticle>();
        }

        public int? RssFeedSubTypeId { get; set; }
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Blurb { get; set; }
        public string WebsiteUrl { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string HtmlUrl { get; set; }
        public string XmlUrl { get; set; }
        public bool Blocked { get; set; }
        public string BlockedReason { get; set; }

        public virtual RssFeedSubtype RssFeedSubType { get; set; }
        public virtual ICollection<RssFeedArticle> RssFeedArticles { get; set; }
    }
}
