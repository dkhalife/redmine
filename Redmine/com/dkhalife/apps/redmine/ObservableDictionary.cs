using System.Collections.Generic;

namespace com.dkhalife.apps.redmine
{
    class ObservableDictionary<T> : Dictionary<int, T>
    {
        private List<string> Index {
            // TODO: Index by name
            get;
        }

        public bool IsChanged { get; private set; }
    }
}