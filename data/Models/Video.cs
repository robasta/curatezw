using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class Video
    {
        public Video()
        {
            TagVideos = new HashSet<TagVideo>();
            VideoPlaylistVideos = new HashSet<VideoPlaylistVideo>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Publisher { get; set; }
        public int? ChannelId { get; set; }
        public string YoutubeCategory { get; set; }
        public string YoutubeChannelId { get; set; }
        public string YoutubeChannelTitle { get; set; }
        public string Slug { get; set; }

        public virtual VideoChannel Channel { get; set; }
        public virtual ICollection<TagVideo> TagVideos { get; set; }
        public virtual ICollection<VideoPlaylistVideo> VideoPlaylistVideos { get; set; }
    }
}
