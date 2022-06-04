using AutoMapper;
using Curate.Data.ViewModels.Video;

namespace Curate.Data.AutoMapper.Profiles
{
    public class VideoProfile : Profile
    {
        private const string YoutubeBaseUrlEmbed = "https://www.youtube.com/embed/";
        public VideoProfile()
        {
            CreateMap<VideoViewModel, Models.Video>()
                .ForMember(dest=> dest.VideoId, opt => opt.MapFrom(src=>src.VideoId))
                .ForMember(dest=> dest.EmbedUrl, opt => opt.MapFrom(src=>src.EmbedUrl))
                .ReverseMap()
                .ForAllOtherMembers(opts => opts.Ignore());

            //CreateMap<PlaylistItem, Models.Video>()
            //    .ForMember(dest=> dest.Title, opt => opt.MapFrom(src=>src.Snippet.Title))
            //    .ForMember(dest => dest.Blurb, opt => opt.MapFrom(src => src.Snippet.Description))
            //    .ForMember(dest => dest.YoutubeChannelTitle, opt => opt.MapFrom(src => src.Snippet.ChannelTitle))
            //    .ForMember(dest => dest.YoutubeChannelId, opt => opt.MapFrom(src => src.Snippet.ChannelId))
            //    .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.Snippet.PublishedAt))
            //    .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Snippet.Thumbnails.Default__.Url))
            //    .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => $"{YoutubeBaseUrlEmbed}{src.Snippet.ResourceId.VideoId}"))
            //    .ForMember(dest=>dest.Slug, opt=> opt.MapFrom<PlaylistItemResolver>())
            //    .ForAllOtherMembers(opts => opts.Ignore());
        }
    }
}
