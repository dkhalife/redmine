using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    public class Reference<T>
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        private static string[] COLORS = { "", "Purple", "Black", "LightBlue", "Orange", "Red" };

        [XmlIgnore]
        public string Color
        {
            get
            {
                if (Id > 0 && Id < 6)
                    return COLORS[Id];

                return "Black";
            }
        }
    }
}