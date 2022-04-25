namespace Curate.Data.ViewModels
{
    public class EntityViewModel
    {
        public string Entity { get; set; }
        public int Count { get; set; }

        public string DisplayValue => $"{Entity} ({Count})";
    }
}