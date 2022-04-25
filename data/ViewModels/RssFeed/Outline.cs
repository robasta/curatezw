using System.Collections.Generic;
using System.Xml.Serialization;

namespace Curate.Data.ViewModels.RssFeed
{
    [XmlRoot(ElementName = "outline")]
    public class Outline
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "xmlUrl")]
        public string XmlUrl { get; set; }
        [XmlAttribute(AttributeName = "htmlUrl")]
        public string HtmlUrl { get; set; }
        [XmlElement(ElementName = "outline")]
        public List<Outline> Feeds { get; set; }

        [XmlAttribute(AttributeName = "subtypeid")]
        public int SubTypeId { get; set; }
    }
}