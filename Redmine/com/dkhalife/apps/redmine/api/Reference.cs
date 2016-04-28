using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    public class Reference<T>
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
