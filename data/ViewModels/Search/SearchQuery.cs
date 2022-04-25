using System.Text;

namespace Curate.Data.ViewModels.Search
{
    public class SearchQuery
    {
        public string q { get; set; }
        public int page { get; set; }

        public int pageSize => 25;

        public string startDate { get; set; }
        public string endDate { get; set; }

        public string ToQueryString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"q={q}");
            if (page > 0)
            {
                sb.Append($"&page={page}");
            }

            if (pageSize > 0)
            {
                sb.Append($"&pageSize={pageSize}");
            }

            if (!string.IsNullOrWhiteSpace(startDate))
            {
                sb.Append($"&startDate={startDate}");
            }
          
            if (!string.IsNullOrWhiteSpace(endDate))
            {
                sb.Append($"&endDate={endDate}");
            }
            return sb.ToString();
        }
    }
}
