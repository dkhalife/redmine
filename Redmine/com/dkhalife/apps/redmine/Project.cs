using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine
{
    public class Project
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("identifier")]
        public string Identifier { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        public enum ProjectStatus
        {
            UNKNOWN = 0,

            [XmlEnum("1")]
            OPEN = 1,

            [XmlEnum("5")]
            CLOSED = 5
        }

        [XmlElement("status")]
        public ProjectStatus Status { get; set; }

        [XmlElement("is_public")]
        public bool IsPublic { get; set; }

        [XmlElement("created_on")]
        public DateTime CreatedOn { get; set; }

        [XmlElement("updated_on")]
        public DateTime UpdatedOn { get; set; }

        [XmlElement("parent")]
        public api.Reference<Project> Parent { get; set; }
    }
}
