using System;

namespace Curate.Web.Utils
{
    public static class Helpers
    {
        public static string GetLastUpdated(string lastUpdated)
        {
            var tryParseDate = DateTime.TryParse(lastUpdated, out var lastUpdatedDate);
            if (!tryParseDate)
            {
                return "a while ago";
            }
            var minutes = DateTime.Now.Subtract(lastUpdatedDate).TotalMinutes;
            if (minutes < 5)
            {
                return "just now";
            }
            else if (minutes < 50)
            {
                return $"a few minutes ago";

            }
            else if (minutes < 119)
            {
                return $"about an hour ago";
            }
            else if (minutes < 1400)
            {
                return $"{Math.Ceiling(minutes / 60)} hours ago";
            }

            return "yesterday";
        }
    }
}
