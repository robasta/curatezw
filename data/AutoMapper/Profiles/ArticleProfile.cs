using AutoMapper;
using Curate.Data.AutoMapper.Resolvers;
using Curate.Data.ViewModels.Article;

namespace Curate.Data.AutoMapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Models.Article, ArticleViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest=> dest.Title, opt => opt.MapFrom(src=>src.Title))
                .ForMember(dest=> dest.Blurb, opt => opt.MapFrom(src=>src.Body))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src=>src.Url))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src=>src.ImageUrl))
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate))
                .ForMember(dest=> dest.LastModifiedDate, opt => opt.MapFrom(src=>src.LastModifiedDate))
                .ForMember(dest=> dest.TagsArticles, opt => opt.MapFrom(src=>src.TagArticles))
                .ForMember(dest=> dest.CollectionArticles, opt => opt.MapFrom(src=>src.CollectionArticles))
                .ForMember(dest=> dest.FeedId, opt => opt.MapFrom(src=>src.RssFeedId))
                .ForMember(dest=>dest.Slug, opt=> opt.MapFrom<ArticleResolver>())
                .ForMember(dest=>dest.Video, opt=>opt.MapFrom(src=>src.Video))
                .ReverseMap()
                .ForAllOtherMembers(opts => opts.Ignore());
        }
    }
}
