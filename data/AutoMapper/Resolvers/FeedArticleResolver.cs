using AutoMapper;
using Curate.Data.Models;
using Curate.Data.Utils;
using Curate.Data.ViewModels.RssFeed;

namespace Curate.Data.AutoMapper.Resolvers
{
    public class FeedArticleResolver : IValueResolver<RssFeedArticle,FeedArticleViewModel, string>
    {
        public string Resolve(RssFeedArticle source, FeedArticleViewModel destination, string destMember, ResolutionContext context)
        {
            return source.Title.GenerateSlug();
        }
    }

   
}
