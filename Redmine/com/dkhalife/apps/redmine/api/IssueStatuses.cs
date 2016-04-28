using com.dkhalife.apps.redmine.core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("issue_statuses")]
    [RedmineApi("issue_statuses")]
    public class IssueStatuses
    {
        [XmlElement("issue_status")]
        public IssueStatus[] Items { get; set; }

        public static async Task<bool> Update(Dictionary<int, IssueStatus> statuses)
        {
            IssueStatuses result = await RedmineApi.GetList<IssueStatuses>();

            statuses.Clear();
            foreach (IssueStatus s in result.Items)
            {
                statuses.Add(s.Id, s);
            }

            return true;
        }
    }
}