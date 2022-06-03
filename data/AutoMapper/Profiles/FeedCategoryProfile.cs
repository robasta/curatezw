using AutoMapper;
using Curate.Data.AutoMapper.Resolvers;
using Curate.Data.ViewModels.RssFeed;

namespace Curate.Data.AutoMapper.Profiles
{
    public class FeedCategoryProfile : Profile
    {
        public FeedCategoryProfile()
        {
            CreateMap<Models.Category, FeedCategoryViewModel>()
                .ForMember(dest=> dest.Title, opt => opt.MapFrom(src=>src.Title))
                .ForMember(dest=> dest.Id, opt => opt.MapFrom(src=>src.Id))
                .ForMember(dest=> dest.SubCategories, opt => opt.MapFrom(src=>src.SubCategories))
                .ForMember(dest=>dest.Slug, opt=> opt.MapFrom<FeedCategoryResolver>())
                .ForAllOtherMembers(opts => opts.Ignore());
        }
    }
}
