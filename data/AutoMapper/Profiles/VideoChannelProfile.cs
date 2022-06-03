using AutoMapper;
using Curate.Data.AutoMapper.Resolvers;
using Curate.Data.Models;
using Google.Apis.YouTube.v3.Data;

namespace Curate.Data.AutoMapper.Profiles
{
    public class VideoChannelProfile : Profile
    {
        public VideoChannelProfile()
        {
            CreateMap<Channel, VideoChannel>()
                //.ForMember(dest=> dest.Title, opt => opt.MapFrom(src=>src.Snippet.Title))
                //.ForMember(dest=> dest.Blurb, opt => opt.MapFrom(src=>src.Snippet.Description))
                .ForMember(dest => dest.ChannelCreationDate, opt => opt.MapFrom(src => src.Snippet.PublishedAt))
                //.ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => src.Snippet.PublishedAt))
                //.ForMember(dest=> dest.Url, opt => opt.MapFrom(src=>src.Snippet.CustomUrl))
                //.ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src=>src.Snippet.Thumbnails.Default__.Url))
                .ForMember(dest=>dest.Slug, opt=> opt.MapFrom<VideoChannelResolver>())
                .ForAllOtherMembers(opts => opts.Ignore());

           
        }
    }
}
