using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class VideoPlaylistVideo
    {
        public int VideoPlaylistId { get; set; }
        public int VideoId { get; set; }
        public int? Position { get; set; }

        public virtual Video Video { get; set; }
        public virtual VideoPlaylist VideoPlaylist { get; set; }
    }
}
