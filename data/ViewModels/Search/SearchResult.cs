using System.Collections.Generic;
using Curate.Data.ViewModels.News;

namespace Curate.Data.ViewModels.Search
{
    public class SearchResult
    {
        public int Count { get; set; }
        public List<MinimalArticle> Hits { get; set; }

    }
}