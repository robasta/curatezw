using Curate.Data.ViewModels.Search;

namespace Curate.Data.ViewModels
{
    public class SearchViewModel:SearchResult
    {
        public string q { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}