using System.Collections.Generic;
using System.Xml.Serialization;
using Windows.Foundation.Collections;

namespace com.dkhalife.apps.redmine
{
    public class ObservableDictionary<T> : Dictionary<int, T>
    {
        private List<string> Index {
            // TODO: optimize
            get
            {
                return null;
            }
        }

        [XmlIgnore]
        public bool IsChanged { get; private set; }
    }
}