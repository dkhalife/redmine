using Redmine.com.dkhalife.apps.redmine.core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("projects")]
    public class Projects : PaginatedList
    {
        [XmlElement("project")]
        public Project[] Items { get; set; }

        public static Progress Progress { get; private set; } = new Progress();

        public static async Task<bool> Update(Dictionary<int, Project> projects, DateTime lastUpdated)
        {
            try
            {
                projects.Clear();
                Projects result = new Projects();
                Progress.Report(0);
                
                do
                {
                    WebRequest wr = RedmineClient.Instance.CreatePaginatedRequest("projects.xml", result);
                    WebResponse response = await wr.GetResponseAsync();
                    XmlSerializer xml = new XmlSerializer(typeof(Projects));
                    result = (Projects)xml.Deserialize(response.GetResponseStream());

                    foreach (Project p in result.Items)
                    {
                        projects.Add(p.Id, p);
                    }

                    Progress.Report(projects.Count * 100.0 / result.TotalCount);
                    result.Offset += result.Limit;
                }
                while (projects.Count < result.TotalCount);
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