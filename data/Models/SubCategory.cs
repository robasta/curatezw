using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            RssFeeds = new HashSet<RssFeed>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<RssFeed> RssFeeds { get; set; }
    }
}
