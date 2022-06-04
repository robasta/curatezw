using AutoMapper;
using Curate.Data.AutoMapper.Resolvers;
using Curate.Data.ViewModels.Category;

namespace Curate.Data.AutoMapper.Profiles
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<Models.SubCategory, SubCategoryViewModel>()
                .ForMember(dest=> dest.Title, opt => opt.MapFrom(src=>src.Title))
                .ForMember(dest=> dest.Id, opt => opt.MapFrom(src=>src.Id))
                .ForMember(dest=> dest.ParentCategory, opt => opt.MapFrom(src=>src.Category))
                .ForMember(dest => dest.Feeds, opt => opt.MapFrom(src=> src.RssFeeds))
                .ForMember(dest=>dest.Slug, opt=> opt.MapFrom<SubCategoryResolver>())
                .ReverseMap()
                .ForAllOtherMembers(opts => opts.Ignore());
        }
    }
}
