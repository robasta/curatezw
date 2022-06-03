using AutoMapper;
using Curate.Data.Models;
using Curate.Data.Utils;
using Curate.Data.ViewModels.RssFeed;

namespace Curate.Data.AutoMapper.Resolvers
{
    public class FeedCategoryResolver : IValueResolver<Category, FeedCategoryViewModel, string>
    {
        public string Resolve(Category source, FeedCategoryViewModel destination, string destMember, ResolutionContext context)
        {
            return source.Title.GenerateSlug();
        }
    }

   
}
