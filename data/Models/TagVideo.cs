using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class TagVideo
    {
        public int TagId { get; set; }
        public int VideoId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Video Video { get; set; }
    }
}
