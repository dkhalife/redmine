using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine
{
    [XmlRoot("tracker")]
    public class Tracker : NamedType
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public override string Name { get; set; }

        [XmlElement("default_status")]
        public api.Reference<IssueStatus> DefaultStatus { get; set; }
    }
}