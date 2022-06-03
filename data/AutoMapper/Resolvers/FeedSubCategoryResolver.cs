using AutoMapper;
using Curate.Data.Models;
using Curate.Data.Utils;
using Curate.Data.ViewModels.RssFeed;

namespace Curate.Data.AutoMapper.Resolvers
{
    public class FeedSubCategoryResolver : IValueResolver<SubCategory, FeedSubCategoryViewModel, string>
    {
        public string Resolve(SubCategory source, FeedSubCategoryViewModel destination, string destMember, ResolutionContext context)
        {
            return source.Title.GenerateSlug();
        }
    }

   
}
