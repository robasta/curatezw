using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class RssFeed
    {
        public RssFeed()
        {
            Articles = new HashSet<Article>();
        }

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
        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public virtual VideoChannel VideoChannel { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
