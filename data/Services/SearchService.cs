using System;
using System.Net.Http;
using System.Threading.Tasks;
using Curate.Data.Services.Interfaces;
using Curate.Data.ViewModels.Search;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Serialization;

namespace Curate.Data.Services
{
    public class SearchService : ISearchService
    {
        private readonly IMemoryCache _cache;
        private readonly MemoryCacheEntryOptions _cacheOptions;

        private DefaultContractResolver _contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };

        public SearchService( IMemoryCache cache)
        {
            _cache = cache;
            _cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };
        }

        public async Task<SearchResult> Search(SearchQuery query)
        {
            throw new HttpRequestException("something went wrong");
        }
    }
}
