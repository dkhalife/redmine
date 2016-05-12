using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine
{
    public class IssueStatus : NamedType
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public override string Name { get; set; }

        [XmlElement("is_closed")]
        public bool IsClosed { get; set; }
    }
}