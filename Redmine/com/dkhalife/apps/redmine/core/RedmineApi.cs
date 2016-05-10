using com.dkhalife.apps.redmine.api;
using System;
using System.Net;
using System.Reflection;
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

        public delegate void OnApiFailureEventHandler(Exception e);

        public static event OnApiFailureEventHandler ApiFailed;

        private static void handleExceptions(Exception e)
        {
            if(ApiFailed == null)
            {
#if DEBUG
                throw e;
#else
                // TODO: Add logging here
                return;
#endif
            }

            ApiFailed(e);
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
