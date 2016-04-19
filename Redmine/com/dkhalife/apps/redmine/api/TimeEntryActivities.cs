using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("time_entry_activities")]
    public class TimeEntryActivities
    {
        [XmlElement("time_entry_activity")]
        public TimeEntryActivity[] Items { get; set; }

        public static async Task<bool> Update(Dictionary<int, TimeEntryActivity> activities)
        {
            try
            {
                WebRequest wr = RedmineClient.Instance.CreateRequest("enumerations/time_entry_activities.xml");

                WebResponse response = await wr.GetResponseAsync();
                XmlSerializer xml = new XmlSerializer(typeof(TimeEntryActivities));
                TimeEntryActivities result = (TimeEntryActivities)xml.Deserialize(response.GetResponseStream());

                activities.Clear();
                foreach (TimeEntryActivity e in result.Items)
                {
                    activities.Add(e.Id, e);
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