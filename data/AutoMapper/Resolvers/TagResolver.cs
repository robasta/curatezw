using AutoMapper;
using Curate.Data.Models;
using Curate.Data.Utils;
using Curate.Data.ViewModels;

namespace Curate.Data.AutoMapper.Resolvers
{
    public class TagResolver : IValueResolver<Tag, TagViewModel, string>
    {
        public string Resolve(Tag source, TagViewModel destination, string destMember, ResolutionContext context)
        {
            return source.Title.GenerateSlug();
        }
    }

   
}
