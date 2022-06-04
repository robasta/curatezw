using System.Collections.Generic;
using Curate.Data.ViewModels.RssFeed;

namespace Curate.Data.ViewModels.Category
{
    public class SubCategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public IEnumerable<FeedViewModel> Feeds { get; set; }

        public CategoryViewModel ParentCategory { get; set; }
    }
}