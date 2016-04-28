using com.dkhalife.apps.redmine.core;
using Redmine.com.dkhalife.apps.redmine.core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("queries")]
    [RedmineApi("queries")]
    public class Queries : PaginatedList
    {
        [XmlElement("query")]
        public Query[] Items { get; set; }

        public static Progress Progress { get; private set; } = new Progress();

        public static async Task<bool> Update(Dictionary<int, Query> queries)
        {
            queries.Clear();
            Queries result = new Queries();
            Progress.Report(0);

            do
            {
                result = await RedmineApi.GetPaginatedList<Queries>(result);

                foreach (Query q in result.Items)
                {
                    queries.Add(q.Id, q);
                }

                Progress.Report(queries.Count * 100 / result.TotalCount);
                result.Offset += result.Limit; 
            }
            while (queries.Count < result.TotalCount);
            Progress.Report(100);

            return true;
        }
    }
}