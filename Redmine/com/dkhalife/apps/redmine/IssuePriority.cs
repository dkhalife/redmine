using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine
{
    public class IssuePriority
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("is_default")]
        public bool IsDefault { get; set; }
    }
}