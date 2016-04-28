using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine
{
    public class Query
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("is_public")]
        public bool IsPublic { get; set; }

        [XmlElement("project_id")]
        public string ProjectId { get; set; }
    }
}