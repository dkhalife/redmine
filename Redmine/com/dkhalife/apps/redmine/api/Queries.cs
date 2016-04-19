using Redmine.com.dkhalife.apps.redmine.core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("queries")]
    public class Queries : PaginatedList
    {
        [XmlElement("query")]
        public Query[] Items { get; set; }

        public static Progress Progress { get; private set; } = new Progress();

        public static async Task<bool> Update(Dictionary<int, Query> queries)
        {
            try
            {
                queries.Clear();
                Queries result = new Queries();
                Progress.Report(0);

                do
                {
                    WebRequest wr = RedmineClient.Instance.CreatePaginatedRequest("queries.xml", result);
                    WebResponse response = await wr.GetResponseAsync();
                    XmlSerializer xml = new XmlSerializer(typeof(Queries));
                    result = (Queries)xml.Deserialize(response.GetResponseStream());

                    foreach (Query q in result.Items)
                    {
                        queries.Add(q.Id, q);
                    }

                    Progress.Report(queries.Count * 100.0 / result.TotalCount);
                    result.Offset += result.Limit; 
                }
                while (queries.Count < result.TotalCount);
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