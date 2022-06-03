using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class RssFeedArticle
    {
        public RssFeedArticle()
        {
            TagRssFeedArticles = new HashSet<TagRssFeedArticle>();
        }

        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Body { get; set; }
        public string Blurb { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? RssFeedId { get; set; }

        public virtual RssFeed RssFeed { get; set; }
        public virtual ICollection<TagRssFeedArticle> TagRssFeedArticles { get; set; }
    }
}
