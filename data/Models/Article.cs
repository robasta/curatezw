using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class Article
    {
        public Article()
        {
            CollectionArticles = new HashSet<CollectionArticle>();
            TagArticles = new HashSet<TagArticle>();
        }

        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Body { get; set; }
        public string Blurb { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? RssFeedId { get; set; }
        public string Slug { get; set; }

        public virtual RssFeed RssFeed { get; set; }
        public virtual Video Video { get; set; }
        public virtual ICollection<CollectionArticle> CollectionArticles { get; set; }
        public virtual ICollection<TagArticle> TagArticles { get; set; }
    }
}
