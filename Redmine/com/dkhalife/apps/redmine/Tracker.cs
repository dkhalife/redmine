using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine
{
    [XmlRoot("tracker")]
    public class Tracker
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("default_status")]
        public api.Reference<IssueStatus> DefaultStatus { get; set; }
    }
}