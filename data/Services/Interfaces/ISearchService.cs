using System.Threading.Tasks;
using Curate.Data.ViewModels.Search;

namespace Curate.Data.Services.Interfaces
{
    public interface ISearchService
    {
        Task<SearchResult> Search(SearchQuery q);
    }
}