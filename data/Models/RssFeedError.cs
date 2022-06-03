using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class RssFeedError
    {
        public int Id { get; set; }
        public int RssFeedId { get; set; }
        public DateTime ErrorDate { get; set; }
        public string Url { get; set; }
        public string ErrorMessage { get; set; }
        public string RssFeedTitle { get; set; }
    }
}
