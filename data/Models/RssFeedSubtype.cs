using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class RssFeedSubtype
    {
        public RssFeedSubtype()
        {
            RssFeeds = new HashSet<RssFeed>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentTypeId { get; set; }

        public virtual RssFeedType ParentType { get; set; }
        public virtual ICollection<RssFeed> RssFeeds { get; set; }
    }
}
