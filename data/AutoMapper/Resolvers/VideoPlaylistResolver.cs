using AutoMapper;
using Curate.Data.Utils;
using Google.Apis.YouTube.v3.Data;

namespace Curate.Data.AutoMapper.Resolvers
{
    public class VideoPlaylistResolver : IValueResolver<Playlist,Models.VideoPlaylist, string>
    {
        public string Resolve(Playlist source, Models.VideoPlaylist destination, string destMember, ResolutionContext context)
        {
            return source.Snippet.Title.GenerateSlug();
        }
    }
}
