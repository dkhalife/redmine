using com.dkhalife.apps.redmine.core;
using System;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine
{
    [XmlRoot("issue")]
    [RedmineApi("issues")]
    public class Issue : NamedType
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("project")]
        public api.Reference<Project> Project { get; set; }

        [XmlElement("tracker")]
        public api.Reference<Tracker> Tracker { get; set; }

        [XmlElement("status")]
        public api.Reference<IssueStatus> Status { get; set; }

        [XmlElement("priority")]
        public api.Reference<IssuePriority> Priority { get; set; }

        [XmlElement("author")]
        public api.Reference<User> Author { get; set; }

        [XmlElement("assigned_to")]
        public api.Reference<User> AssignedTo { get; set; }

        [XmlElement("subject")]
        public string Subject { get; set; }

        [XmlIgnore]
        public override string Name {
            get
            {
                return Subject;
            }
            set
            {
                Subject = value;
            }
        }

        [XmlElement("description")]
        public string Description { get; set; }
        
        [XmlElement("start_date")]
        public DateTime StartDate { get; set; }

        /*[XmlElement("due_date")]
        public DateTime DueDate { get; set; }*/

        [XmlElement("done_ratio")]
        public int DoneRatio { get; set; }

        [XmlElement("is_private")]
        public bool IsPrivate { get; set; }

        /*[XmlElement("estimated_hours")]
        public decimal EstimatedHours { get; set; }*/
        
        [XmlElement("created_on")]
        public DateTime CreatedOn { get; set; }

        [XmlElement("updated_on")]
        public DateTime UpdatedOn { get; set; }

        /*
[XmlElement("closed_on")]
public DateTime ClosedOn { get; set; }*/
    }
}
