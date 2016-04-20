using Redmine.com.dkhalife.apps.redmine.core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("users")]
    public class Users : PaginatedList
    {
        [XmlElement("user")]
        public User[] Items { get; set; }

        public static Progress Progress { get; private set; } = new Progress();

        public static async Task<User> Get(int user_id)
        {
            try
            {
                WebRequest wr = RedmineClient.Instance.CreateRequest($"users/{user_id}.xml");
                WebResponse response = await wr.GetResponseAsync();
                XmlSerializer xml = new XmlSerializer(typeof(User));
                return (User)xml.Deserialize(response.GetResponseStream());
            }
            catch
            {
                return null;
            }
        }

        public static async Task<bool> Update(Dictionary<int, User> users)
        {
            try
            {
                users.Clear();
                Users result = new Users();
                Progress.Report(0);

                do
                {
                    WebRequest wr = RedmineClient.Instance.CreatePaginatedRequest("users.xml", result);
                    WebResponse response = await wr.GetResponseAsync();
                    XmlSerializer xml = new XmlSerializer(typeof(Users));
                    result = (Users)xml.Deserialize(response.GetResponseStream());

                    foreach (User u in result.Items)
                    {
                        users.Add(u.Id, u);
                    }

                    Progress.Report(users.Count * 100.0 / result.TotalCount);
                    result.Offset += result.Limit;
                }
                while (users.Count < result.TotalCount);
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