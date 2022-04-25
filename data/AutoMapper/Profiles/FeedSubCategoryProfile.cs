using AutoMapper;
using Curate.Data.AutoMapper.Resolvers;
using Curate.Data.ViewModels.RssFeed;

namespace Curate.Data.AutoMapper.Profiles
{
    public class FeedSubCategoryProfile : Profile
    {
        public FeedSubCategoryProfile()
        {
            CreateMap<Models.RssFeedSubtype, FeedSubCategoryViewModel>()
                .ForMember(dest=> dest.Title, opt => opt.MapFrom(src=>src.Title))
                .ForMember(dest=> dest.Id, opt => opt.MapFrom(src=>src.Id))
                .ForMember(dest=> dest.ParentCategory, opt => opt.MapFrom(src=>src.ParentType))
                .ForMember(dest => dest.Feeds, opt => opt.MapFrom(src=> src.RssFeeds))
                .ForMember(dest=>dest.Slug, opt=> opt.MapFrom<FeedSubCategoryResolver>())
                .ForAllOtherMembers(opts => opts.Ignore());
        }
    }
}
