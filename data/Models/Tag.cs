using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class Tag
    {
        public Tag()
        {
            TagPosts = new HashSet<TagPost>();
            TagRssFeedArticles = new HashSet<TagRssFeedArticle>();
            TagVideoChannels = new HashSet<TagVideoChannel>();
            TagVideos = new HashSet<TagVideo>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }

        public virtual ICollection<TagPost> TagPosts { get; set; }
        public virtual ICollection<TagRssFeedArticle> TagRssFeedArticles { get; set; }
        public virtual ICollection<TagVideoChannel> TagVideoChannels { get; set; }
        public virtual ICollection<TagVideo> TagVideos { get; set; }
    }
}
