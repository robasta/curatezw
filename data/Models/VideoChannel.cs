using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class VideoChannel
    {
        public int Id { get; set; }
        public DateTime? ChannelCreationDate { get; set; }
        public string Slug { get; set; }
        public string ChannelId { get; set; }

        public virtual RssFeed IdNavigation { get; set; }
    }
}
