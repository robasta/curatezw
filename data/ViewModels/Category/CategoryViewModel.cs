using System.Collections.Generic;

namespace Curate.Data.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }

        public IEnumerable<SubCategoryViewModel> SubCategories { get; set; }
    }
}