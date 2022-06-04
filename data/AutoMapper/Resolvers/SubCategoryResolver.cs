using AutoMapper;
using Curate.Data.Models;
using Curate.Data.Utils;
using Curate.Data.ViewModels.Category;

namespace Curate.Data.AutoMapper.Resolvers
{
    public class SubCategoryResolver : IValueResolver<SubCategory, SubCategoryViewModel, string>
    {
        public string Resolve(SubCategory source, SubCategoryViewModel destination, string destMember, ResolutionContext context)
        {
            return source.Title.GenerateSlug();
        }
    }

   
}
