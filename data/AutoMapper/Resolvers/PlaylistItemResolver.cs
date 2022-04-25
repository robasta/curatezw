using AutoMapper;
using Curate.Data.Utils;
using Google.Apis.YouTube.v3.Data;

namespace Curate.Data.AutoMapper.Resolvers
{
    public class PlaylistItemResolver : IValueResolver<PlaylistItem, Models.Video, string>
    {
        public string Resolve(PlaylistItem source, Models.Video destination, string destMember, ResolutionContext context)
        {
            return source.Snippet.Title.GenerateSlug();
        }

    }
}