using com.dkhalife.apps.redmine;
using com.dkhalife.apps.redmine.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine.core
{
    [AttributeUsage(AttributeTargets.Class)]
    class RedmineApi : Attribute
    {
        public RedmineApi(string path)
        {
            Path = path;
        }

        public string Path { get; set; }

        private static void handleExceptions(Exception e)
        {
            // TODO: well implement it
            throw new NotImplementedException();
        }

        public static async Task<T> GetSingle<T>(int id)
        {
            try
            {
                Type type = typeof(T);
                RedmineApi api = type.GetTypeInfo().GetCustomAttribute<RedmineApi>();

                WebRequest wr = RedmineClient.Instance.CreateRequest(api.Path + $"/{id}.xml");
                WebResponse response = await wr.GetResponseAsync();
                XmlSerializer xml = new XmlSerializer(type);

                return (T)xml.Deserialize(response.GetResponseStream());
            }
            catch(Exception e)
            {
                handleExceptions(e);
                return default(T);
            }
        }

        public static async Task<T> GetList<T>()
        {
            try
            {
                Type type = typeof(T);
                RedmineApi api = type.GetTypeInfo().GetCustomAttribute<RedmineApi>();

                WebRequest wr = RedmineClient.Instance.CreateRequest(api.Path + ".xml");
                WebResponse response = await wr.GetResponseAsync();
                XmlSerializer xml = new XmlSerializer(type);

                return (T) xml.Deserialize(response.GetResponseStream());
            }
            catch(Exception e)
            {
                handleExceptions(e);
                return default(T);
            }
        }

        public static async Task<T> GetPaginatedList<T>(T page, string filter = "") where T : PaginatedList
        {
            try
            {
                Type type = typeof(T);
                RedmineApi api = type.GetTypeInfo().GetCustomAttribute<RedmineApi>();

                WebRequest wr = RedmineClient.Instance.CreatePaginatedRequest(api.Path + ".xml", page, filter);
                WebResponse response = await wr.GetResponseAsync();
                XmlSerializer xml = new XmlSerializer(type);

                return (T)xml.Deserialize(response.GetResponseStream());
            }
            catch (Exception e)
            {
                handleExceptions(e);
                return default(T);
            }
        }
    }
}
