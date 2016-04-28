using com.dkhalife.apps.redmine.core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("issue_priorities")]
    [RedmineApi("enumerations/issue_priorities")]
    public class IssuePriorities
    {
        [XmlElement("issue_priority")]
        public IssuePriority[] Items { get; set; }

        public static async Task<bool> Update(Dictionary<int, IssuePriority> priorities)
        {
            IssuePriorities result = await RedmineApi.GetList<IssuePriorities>();

            priorities.Clear();
            foreach (IssuePriority p in result.Items)
            {
                priorities.Add(p.Id, p);
            }

            return true;
        }
    }
}