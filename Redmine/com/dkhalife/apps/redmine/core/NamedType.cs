using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine
{
    public abstract class NamedType
    {
        [XmlIgnore]
        public abstract string Name { get; set; }
    }
}