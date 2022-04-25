using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Curate.Data.ViewModels.News
{
    public class LatestNews
    {
        public DateTime Date { get; set; }

        [JsonProperty("create_date")]
        public DateTime CreateDate { get; set; }

        public List<CategorizedItems> Categories { get; set; }
    }
}