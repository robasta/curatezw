using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class Tag
    {
        public Tag()
        {
            TagArticles = new HashSet<TagArticle>();
            TagPosts = new HashSet<TagPost>();
            TagVideoChannels = new HashSet<TagVideoChannel>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }

        public virtual ICollection<TagArticle> TagArticles { get; set; }
        public virtual ICollection<TagPost> TagPosts { get; set; }
        public virtual ICollection<TagVideoChannel> TagVideoChannels { get; set; }
    }
}
