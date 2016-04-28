using com.dkhalife.apps.redmine.core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("time_entry_activities")]
    [RedmineApi("enumerations/time_entry_activities")]
    public class TimeEntryActivities
    {
        [XmlElement("time_entry_activity")]
        public TimeEntryActivity[] Items { get; set; }

        public static async Task<bool> Update(Dictionary<int, TimeEntryActivity> activities)
        {
            TimeEntryActivities result = await RedmineApi.GetList<TimeEntryActivities>();

            activities.Clear();
            foreach (TimeEntryActivity e in result.Items)
            {
                activities.Add(e.Id, e);
            }

            return true;
        }
    }
}