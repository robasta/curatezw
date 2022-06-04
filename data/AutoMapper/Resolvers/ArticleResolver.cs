using AutoMapper;
using Curate.Data.Models;
using Curate.Data.Utils;
using Curate.Data.ViewModels.Article;

namespace Curate.Data.AutoMapper.Resolvers
{
    public class ArticleResolver : IValueResolver<Article,ArticleViewModel, string>
    {
        public string Resolve(Article source, ArticleViewModel destination, string destMember, ResolutionContext context)
        {
            return source.Title.GenerateSlug();
        }
    }

   
}
