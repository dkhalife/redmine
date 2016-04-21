using com.dkhalife.apps.redmine.core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("trackers")]
    [RedmineApi("trackers")]
    public class Trackers
    {
        [XmlElement("tracker")]
        public Tracker[] Items { get; set; }

        public static async Task<bool> Update(Dictionary<int, Tracker> trackers)
        {
            Trackers result = await RedmineApi.GetList<Trackers>();

            trackers.Clear();
            foreach (Tracker t in result.Items)
            {
                trackers.Add(t.Id, t);
            }

            return true;
        }
    }
}