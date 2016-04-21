using com.dkhalife.apps.redmine.core;
using Redmine.com.dkhalife.apps.redmine.core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("time_entries")]
    [RedmineApi("time_entries")]
    public class TimeEntries : PaginatedList
    {
        [XmlElement("time_entry")]
        public TimeEntry[] Items { get; set; }

        public static Progress Progress { get; private set; } = new Progress();

        public static async Task<bool> Update(Dictionary<int, TimeEntry> timeEntries)
        {
            timeEntries.Clear();
            TimeEntries result = new TimeEntries();
            Progress.Report(0);

            do
            {
                result = await RedmineApi.GetPaginatedList<TimeEntries>(result);

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
    }
}