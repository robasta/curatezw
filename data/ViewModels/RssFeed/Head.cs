using System.Xml.Serialization;

namespace Curate.Data.ViewModels.RssFeed
{
    [XmlRoot(ElementName = "head")]
    public class Head
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
    }
}