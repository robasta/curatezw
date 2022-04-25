using System;
using Curate.Data.Models;

namespace Curate.Data.Exceptions
{
    public class BlockedFeedException : Exception
    {
        public BlockedFeedException(RssFeed feed)
        {
            Feed = feed;
        }

        public override string Message => $"{Feed.Id} is blocked because \"{Feed.BlockedReason}\"";

        public RssFeed Feed { get; set; }
    }
}
