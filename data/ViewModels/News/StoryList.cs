using System.Collections.Generic;

namespace Curate.Data.ViewModels.News
{
    public class StoryList
    {
        public string Date { get; set; }
        public List<Story> Stories { get; set; }
    }
}