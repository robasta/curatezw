using AutoMapper;
using Curate.Data.Models;
using Curate.Data.Utils;
using Curate.Data.ViewModels.RssFeed;

namespace Curate.Data.AutoMapper.Resolvers
{
    public class FeedSubCategoryResolver : IValueResolver<RssFeedSubtype, FeedSubCategoryViewModel, string>
    {
        public string Resolve(RssFeedSubtype source, FeedSubCategoryViewModel destination, string destMember, ResolutionContext context)
        {
            return source.Title.GenerateSlug();
        }
    }

   
}
