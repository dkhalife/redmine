using Redmine.com.dkhalife.apps.redmine.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    public abstract class PaginatedList
    {
        [XmlAttribute("total_count")]
        public int TotalCount { get; set; }

        [XmlAttribute("offset")]
        public int Offset { get; set; } = 0;

        [XmlAttribute("limit")]
        public int Limit { get; set; } = 100;
    }
}
