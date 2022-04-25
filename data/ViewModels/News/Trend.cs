using Newtonsoft.Json;

namespace Curate.Data.ViewModels.News
{
    public class Trend
    {
        [JsonProperty("entity")]
        public string Name { get; set; }
        public int Count { get; set; }
    }
}