using System.Collections.Generic;
using System.Xml.Serialization;

namespace Curate.Data.ViewModels.RssFeed
{
    [XmlRoot(ElementName = "body")]
    public class Body
    {
        [XmlElement(ElementName = "outline")]
        public List<Outline> Outline { get; set; }
    }
}