using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class Video
    {
        public Video()
        {
            VideoPlaylistVideos = new HashSet<VideoPlaylistVideo>();
        }

        public int Id { get; set; }
        public string EmbedUrl { get; set; }
        public string VideoId { get; set; }

        public virtual Article Article { get; set; }
        public virtual ICollection<VideoPlaylistVideo> VideoPlaylistVideos { get; set; }
    }
}
