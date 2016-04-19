using System;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine
{
    public class TimeEntry
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("project")]
        public api.Reference<Project> Project { get; set; }

        [XmlElement("issue")]
        public api.Reference<Issue> Issue { get; set; }

        [XmlElement("user")]
        public api.Reference<User> User { get; set; }

        [XmlElement("activity")]
        public api.Reference<TimeEntryActivity> Activity { get; set; }

        [XmlElement("hours")]
        public decimal Hours { get; set; }

        [XmlElement("comments")]
        public string Comments { get; set; }

        [XmlElement("spent_on")]
        public DateTime SpentOn { get; set; }

        [XmlElement("created_on")]
        public DateTime CreatedOn { get; set; }

        [XmlElement("updated_on")]
        public DateTime UpdatedOn{ get; set; }
    }
}