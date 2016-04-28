using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    class ErrorList
    {
        [XmlElement("error")]
        public string[] Errors { get; set; }
    }
}
