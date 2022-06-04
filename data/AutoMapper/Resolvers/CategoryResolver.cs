using AutoMapper;
using Curate.Data.Models;
using Curate.Data.Utils;
using Curate.Data.ViewModels.Category;

namespace Curate.Data.AutoMapper.Resolvers
{
    public class CategoryResolver : IValueResolver<Category, CategoryViewModel, string>
    {
        public string Resolve(Category source, CategoryViewModel destination, string destMember, ResolutionContext context)
        {
            return source.Title.GenerateSlug();
        }
    }

   
}
