using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class RssFeedType
    {
        public RssFeedType()
        {
            RssFeedSubtypes = new HashSet<RssFeedSubtype>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<RssFeedSubtype> RssFeedSubtypes { get; set; }
    }
}
