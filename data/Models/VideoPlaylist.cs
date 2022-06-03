using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class VideoPlaylist
    {
        public VideoPlaylist()
        {
            VideoPlaylistVideos = new HashSet<VideoPlaylistVideo>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string YoutubeChannelId { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<VideoPlaylistVideo> VideoPlaylistVideos { get; set; }
    }
}
