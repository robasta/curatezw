using AutoMapper;
using Curate.Data.Models;
using Curate.Data.Utils;
using Curate.Data.ViewModels.RssFeed;

namespace Curate.Data.AutoMapper.Resolvers
{
    public class FeedArticleResolver : IValueResolver<Article,FeedArticleViewModel, string>
    {
        public string Resolve(Article source, FeedArticleViewModel destination, string destMember, ResolutionContext context)
        {
            return source.Title.GenerateSlug();
        }
    }

   
}
