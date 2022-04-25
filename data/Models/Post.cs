using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class Post
    {
        public Post()
        {
            TagPosts = new HashSet<TagPost>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int? Status { get; set; }
        public string Slug { get; set; }
        public int CharacterCount { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<TagPost> TagPosts { get; set; }
    }
}
