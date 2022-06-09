﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class TagArticle
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
