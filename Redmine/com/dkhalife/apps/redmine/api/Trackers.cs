using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("trackers")]
    public class Trackers
    {

        [XmlElement("tracker")]
        public Tracker[] Items { get; set; }

        public static async Task<bool> Update(Dictionary<int, Tracker> trackers)
        {
            try
            {
                WebRequest wr = RedmineClient.Instance.CreateRequest("trackers.xml");

                WebResponse response = await wr.GetResponseAsync();
                XmlSerializer xml = new XmlSerializer(typeof(Trackers));
                Trackers result = (Trackers)xml.Deserialize(response.GetResponseStream());

                trackers.Clear();
                foreach (Tracker t in result.Items)
                {
                    trackers.Add(t.Id, t);
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