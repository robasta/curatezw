using System;

#nullable disable

namespace Curate.Data.Models
{
    public partial class VideoChannel
    {
        public int RssFeedId { get; set; }
        public DateTime? ChannelCreationDate { get; set; }
        public string Slug { get; set; }
        public string ChannelId { get; set; }

        public virtual RssFeed RssFeed { get; set; }
    }
}
