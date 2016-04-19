using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("issue_priorities")]
    public class IssuePriorities
    {
        [XmlElement("issue_priority")]
        public IssuePriority[] Items { get; set; }

        public static async Task<bool> Update(Dictionary<int, IssuePriority> priorities)
        {
            try
            {
                WebRequest wr = RedmineClient.Instance.CreateRequest("enumerations/issue_priorities.xml");

                WebResponse response = await wr.GetResponseAsync();
                XmlSerializer s = new XmlSerializer(typeof(IssuePriorities));
                IssuePriorities result = (IssuePriorities) s.Deserialize(response.GetResponseStream());

                priorities.Clear();
                foreach (IssuePriority p in result.Items)
                {
                    priorities.Add(p.Id, p);
                }

                return true;
            }
            catch
            {
                // TODO: Log the exception
                return false;
            }
        }
    }
}