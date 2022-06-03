using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class Collection
    {
        public Collection()
        {
            CollectionArticles = new HashSet<CollectionArticle>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<CollectionArticle> CollectionArticles { get; set; }
    }
}
