using AutoMapper;
using Curate.Data.AutoMapper.Resolvers;
using Curate.Data.ViewModels.Category;

namespace Curate.Data.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Models.Category, CategoryViewModel>()
                .ForMember(dest=> dest.Title, opt => opt.MapFrom(src=>src.Title))
                .ForMember(dest=> dest.Id, opt => opt.MapFrom(src=>src.Id))
                .ForMember(dest=> dest.SubCategories, opt => opt.MapFrom(src=>src.SubCategories))
                .ForMember(dest=>dest.Slug, opt=> opt.MapFrom<CategoryResolver>())
                .ReverseMap()
                .ForAllOtherMembers(opts => opts.Ignore());
        }
    }
}
