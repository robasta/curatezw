using AutoMapper;
using Curate.Data.AutoMapper.Resolvers;
using Curate.Data.ViewModels.RssFeed;

namespace Curate.Data.AutoMapper.Profiles
{
    public class FeedProfile : Profile
    {
        public FeedProfile()
        {
            CreateMap<Models.RssFeed, FeedViewModel>()
                .ForMember(dest=> dest.Title, opt => opt.MapFrom(src=>src.Title))
                .ForMember(dest=> dest.Blurb, opt => opt.MapFrom(src=>src.Blurb))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src=>src.XmlUrl))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src=>src.ImageUrl))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.WebsiteUrl, opt => opt.MapFrom(src => src.HtmlUrl))
                .ForMember(dest=> dest.LastUpdated, opt => opt.MapFrom(src=>src.LastUpdated))
                .ForMember(dest=> dest.Category, opt => opt.MapFrom(src=>src.SubCategory.Category))
                .ForMember(dest => dest.SubCategory, opt=> opt.MapFrom(src=> src.SubCategory))
                .ForMember(dest => dest.Blocked, opt=> opt.MapFrom(src=> src.Blocked))
                .ForMember(dest => dest.BlockedReason, opt=> opt.MapFrom(src=> src.BlockedReason))
                .ForMember(dest => dest.Articles, opt=> opt.MapFrom(src=> src.Articles))
                .ForMember(dest=>dest.Slug, opt=> opt.MapFrom<FeedResolver>())
                .ForAllOtherMembers(opts => opts.Ignore());
        }
    }
}
