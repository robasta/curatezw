using System.Collections.Generic;

namespace Curate.Data.ViewModels.News
{
    public class CategorizedItems
    {
        public Category Category { get; set; }
        public List<MinimalArticle> Articles { get; set; }
    }
}
