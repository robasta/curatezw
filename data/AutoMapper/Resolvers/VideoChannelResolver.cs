using AutoMapper;
using Curate.Data.Models;
using Curate.Data.Utils;
using Google.Apis.YouTube.v3.Data;

namespace Curate.Data.AutoMapper.Resolvers
{
    public class VideoChannelResolver : IValueResolver<Channel,VideoChannel, string>
    {
        public string Resolve(Channel source, VideoChannel destination, string destMember, ResolutionContext context)
        {
            return source.Snippet.Title.GenerateSlug();
        }
    }
}
