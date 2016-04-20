using Redmine.com.dkhalife.apps.redmine.core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("time_entries")]
    public class TimeEntries : PaginatedList
    {
        [XmlElement("time_entry")]
        public TimeEntry[] Items { get; set; }

        public static Progress Progress { get; private set; } = new Progress();

        public static async Task<bool> Update(Dictionary<int, TimeEntry> timeEntries)
        {
            try
            {
                timeEntries.Clear();
                TimeEntries result = new TimeEntries();
                Progress.Report(0);

                do
                {
                    WebRequest wr = RedmineClient.Instance.CreatePaginatedRequest("time_entries.xml", result);
                    WebResponse response = await wr.GetResponseAsync();
                    XmlSerializer xml = new XmlSerializer(typeof(TimeEntries));
                    result = (TimeEntries)xml.Deserialize(response.GetResponseStream());
                    
                    foreach (TimeEntry e in result.Items)
                    {
                        timeEntries.Add(e.Id, e);
                    }

                    Progress.Report(timeEntries.Count * 100.0 / result.TotalCount);
                    result.Offset += result.Limit;
                }
                while (timeEntries.Count < result.TotalCount);
                Progress.Report(100);

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