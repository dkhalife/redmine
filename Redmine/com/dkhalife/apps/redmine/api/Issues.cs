using com.dkhalife.apps.redmine.core;
using Redmine.com.dkhalife.apps.redmine.core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("issues")]
    [RedmineApi("issues")]
    public class Issues : PaginatedList
    {
        [XmlElement("issue")]
        public Issue[] Items { get; set; }

        public static Progress Progress { get; private set; } = new Progress();

        public static async Task<Issue> Get(int issue_id)
        {
            return await RedmineApi.GetSingle<Issue>(issue_id);
        }

        public static async Task<bool> Update(Dictionary<int, Issue> issues, DateTime lastUpdated)
        {
            Issues result = new Issues();
            Progress.Report(0);

            string since = lastUpdated.ToString("yyyy-MM-dd\\THH:mm:ss\\Z");

            do
            {
                result = await RedmineApi.GetPaginatedList<Issues>(result, $"updated_on=%3E%3D{since}");

                if (result == null)
                    return false;
                
                foreach (Issue i in result.Items)
                {
                    if (issues.ContainsKey(i.Id))
                        issues[i.Id] = i;
                    else
                        issues.Add(i.Id, i);
                }

                Progress.Report(issues.Count * 100 / result.TotalCount);
                result.Offset += result.Limit;
            }
            while (issues.Count < result.TotalCount);
            Progress.Report(100);

            return true;
        }
    }
}