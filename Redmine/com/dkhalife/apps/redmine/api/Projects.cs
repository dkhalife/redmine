using com.dkhalife.apps.redmine.core;
using Redmine.com.dkhalife.apps.redmine.core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("projects")]
    [RedmineApi("projects")]
    public class Projects : PaginatedList
    {
        [XmlElement("project")]
        public Project[] Items { get; set; }

        public static Progress Progress { get; private set; } = new Progress();

        public static async Task<Project> Get(int project_id)
        {
            return await RedmineApi.GetSingle<Project>(project_id);
        }

        public static async Task<bool> Update(Dictionary<int, Project> projects)
        {
            projects.Clear();
            Projects result = new Projects();
            Progress.Report(0);
                
            do
            {
                result = await RedmineApi.GetPaginatedList<Projects>(result);

                foreach (Project p in result.Items)
                {
                    projects.Add(p.Id, p);
                }

                Progress.Report(projects.Count * 100 / result.TotalCount);
                result.Offset += result.Limit;
            }
            while (projects.Count < result.TotalCount);
            Progress.Report(100);

            return true;
        }
    }
}