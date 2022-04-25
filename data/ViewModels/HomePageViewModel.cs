using System.Collections.Generic;
using Curate.Data.ViewModels.News;

namespace Curate.Data.ViewModels
{
    public class HomePageViewModel
    {
        public List<CategorizedItems> LatestNews { get; set; }
        public bool HasError { get; set; }
        
    }
}
