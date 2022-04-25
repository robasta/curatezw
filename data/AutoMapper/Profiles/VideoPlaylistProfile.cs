using AutoMapper;
using Curate.Data.AutoMapper.Resolvers;
using Google.Apis.YouTube.v3.Data;

namespace Curate.Data.AutoMapper.Profiles
{
    public class VideoPlaylistProfile: Profile
    {
        public VideoPlaylistProfile()
        {
            CreateMap<Playlist, Models.VideoPlaylist>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Snippet.Title))
                .ForMember(dest => dest.Blurb, opt => opt.MapFrom(src => src.Snippet.Description))
                .ForMember(dest => dest.YoutubeChannelId, opt => opt.MapFrom(src => src.Snippet.ChannelId))
                .ForMember(dest => dest.YoutubeChannelTitle, opt => opt.MapFrom(src => src.Snippet.ChannelTitle))
                .ForMember(dest=> dest.PublishDate, opt => opt.MapFrom(src=>src.Snippet.PublishedAt))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Snippet.Thumbnails.Default__.Url))
                .ForMember(dest => dest.Slug, opt => opt.MapFrom<VideoPlaylistResolver>())
                .ForAllOtherMembers(opts => opts.Ignore());
        }
    }
}
