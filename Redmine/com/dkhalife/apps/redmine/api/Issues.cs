using Redmine.com.dkhalife.apps.redmine.core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("issues")]
    public class Issues : PaginatedList
    {
        [XmlElement("issue")]
        public Issue[] Items { get; set; }

        public static Progress Progress { get; private set; } = new Progress();

        public static async Task<bool> Update(Dictionary<int, Issue> issues, DateTime lastUpdated)
        {
            try
            {
                issues.Clear();
                Issues result = new Issues();
                Progress.Report(0);

                do
                {
                    WebRequest wr = RedmineClient.Instance.CreatePaginatedRequest("issues.xml", result);
                    WebResponse response = await wr.GetResponseAsync();
                    XmlSerializer xml = new XmlSerializer(typeof(Issues));
                    result = (Issues)xml.Deserialize(response.GetResponseStream());

                    foreach (Issue i in result.Items)
                    {
                        issues.Add(i.Id, i);
                    }

                    Progress.Report(issues.Count * 100.0 / result.TotalCount);
                    result.Offset += result.Limit;
                }
                while (issues.Count < result.TotalCount);
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