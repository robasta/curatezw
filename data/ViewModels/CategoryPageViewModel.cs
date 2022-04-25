using Curate.Data.ViewModels.News;

namespace Curate.Data.ViewModels
{
    public class CategoryPageViewModel
    {
        public CategorizedItems Category { get; set; }
        public string CategoryName => Category?.Category.Name;
    }
}