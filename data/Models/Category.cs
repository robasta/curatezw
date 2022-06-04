using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
