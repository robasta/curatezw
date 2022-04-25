using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class VideoChannel
    {
        public VideoChannel()
        {
            TagVideoChannels = new HashSet<TagVideoChannel>();
            VideoPlaylists = new HashSet<VideoPlaylist>();
            Videos = new HashSet<Video>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Blurb { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? ChannelCreationDate { get; set; }
        public string YoutubeChannelId { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<TagVideoChannel> TagVideoChannels { get; set; }
        public virtual ICollection<VideoPlaylist> VideoPlaylists { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
