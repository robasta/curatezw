using AutoMapper;
using Curate.Data.Models;
using Curate.Data.Utils;
using Curate.Data.ViewModels.RssFeed;

namespace Curate.Data.AutoMapper.Resolvers
{
    public class FeedCategoryResolver : IValueResolver<RssFeedType, FeedCategoryViewModel, string>
    {
        public string Resolve(RssFeedType source, FeedCategoryViewModel destination, string destMember, ResolutionContext context)
        {
            return source.Title.GenerateSlug();
        }
    }

   
}
