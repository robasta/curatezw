﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class TagVideoChannel
    {
        public int TagId { get; set; }
        public int VideoChannelId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
