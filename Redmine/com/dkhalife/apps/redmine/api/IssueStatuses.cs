using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("issue_statuses")]
    public class IssueStatuses
    {
        [XmlElement("issue_status")]
        public IssueStatus[] Items { get; set; }

        public static async Task<bool> Update(Dictionary<int, IssueStatus> statuses)
        {
            try
            {
                WebRequest wr = RedmineClient.Instance.CreateRequest("issue_statuses.xml");

                WebResponse response = await wr.GetResponseAsync();
                XmlSerializer xml = new XmlSerializer(typeof(IssueStatuses));
                IssueStatuses result = (IssueStatuses)xml.Deserialize(response.GetResponseStream());

                statuses.Clear();
                foreach (IssueStatus s in result.Items)
                {
                    statuses.Add(s.Id, s);
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