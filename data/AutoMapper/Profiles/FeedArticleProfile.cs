using AutoMapper;
using Curate.Data.AutoMapper.Resolvers;
using Curate.Data.ViewModels.RssFeed;

namespace Curate.Data.AutoMapper.Profiles
{
    public class FeedArticleProfile : Profile
    {
        public FeedArticleProfile()
        {
            CreateMap<Models.RssFeedArticle, FeedArticleViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest=> dest.Title, opt => opt.MapFrom(src=>src.Title))
                .ForMember(dest=> dest.Body, opt => opt.MapFrom(src=>src.Body))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src=>src.Url))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src=>src.ImageUrl))
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate))
                .ForMember(dest=> dest.LastModifiedDate, opt => opt.MapFrom(src=>src.LastModifiedDate))
                .ForMember(dest=> dest.Tags, opt => opt.MapFrom(src=>src.TagRssFeedArticles))
                .ForMember(dest=> dest.FeedId, opt => opt.MapFrom(src=>src.RssFeedId))
                .ForMember(dest=>dest.Slug, opt=> opt.MapFrom<FeedArticleResolver>())
                .ForAllOtherMembers(opts => opts.Ignore());
        }
    }
}
