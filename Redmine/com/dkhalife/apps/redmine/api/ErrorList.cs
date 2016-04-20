using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    class ErrorList
    {
        [XmlElement("error")]
        public string[] Errors { get; set; }
    }
}
