using com.dkhalife.apps.redmine.core;
using Redmine.com.dkhalife.apps.redmine.core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.api
{
    [XmlRoot("users")]
    [RedmineApi("users")]
    public class Users : PaginatedList
    {
        [XmlElement("user")]
        public User[] Items { get; set; }

        public static Progress Progress { get; private set; } = new Progress();

        public static async Task<User> Get(int user_id)
        {
            return await RedmineApi.GetSingle<User>(user_id);
        }

        public static async Task<bool> Update(Dictionary<int, User> users)
        {
            users.Clear();
            Users result = new Users();
            Progress.Report(0);

            do
            {
                result = await RedmineApi.GetPaginatedList<Users>(result);

                foreach (User u in result.Items)
                {
                    users.Add(u.Id, u);
                }

                Progress.Report(users.Count * 100 / result.TotalCount);
                result.Offset += result.Limit;
            }
            while (users.Count < result.TotalCount);
            Progress.Report(100);

            return true;
        }
    }
}