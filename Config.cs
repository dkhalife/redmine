using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimer
{
    class Config
    {
        public static int PROTOCOL;
        public static string HOST;
        public static string LOCATION
        {
            get
            {
                return (Config.PROTOCOL == 0 ? "http" : "https") + "://" + Config.HOST + "/";
            }
        }
        public static int AUTHENTICATION_METHOD;
        public static string USERNAME;
        public static string PASSWORD;

        private static string FileName = "Settings.dat";

        public delegate void TestCallback(bool success);

        public static void Load()
        {
            try
            {
                using (BinaryReader r = new BinaryReader(File.Open(FileName, FileMode.Open)))
                {
                    int l = (int)r.ReadDouble();
                    string s = Encoding.UTF8.GetString(r.ReadBytes(l));

                    byte[] bytes = Convert.FromBase64String(s);
                    String str = Encoding.UTF8.GetString(bytes);

                    string[] c = str.Split(';');
                    PROTOCOL = int.Parse(c[0]);
                    HOST = c[1];
                    AUTHENTICATION_METHOD = int.Parse(c[2]);
                    USERNAME = c[3];
                    PASSWORD = c[4];
                }
            }
            catch (Exception e)
            {
                Console.Write("Error reading settings, loaded default values. Exception {0}", e.Message);

                PROTOCOL = 0;
                HOST = "";
                AUTHENTICATION_METHOD = 1;
                USERNAME = "";
                PASSWORD = "";
            }
        }

        public static void Save()
        {
            StringBuilder sb = new StringBuilder(String.Empty);
            sb.Append(PROTOCOL).Append(';').Append(HOST).Append(';').Append(AUTHENTICATION_METHOD).Append(';').Append(USERNAME).Append(';').Append(PASSWORD);
            String str = sb.ToString();

            byte[] bytes = Encoding.UTF8.GetBytes(str);
            using (BinaryWriter w = new BinaryWriter(File.Open(FileName, FileMode.OpenOrCreate)))
            {
                byte[] s = Encoding.UTF8.GetBytes(Convert.ToBase64String(bytes));
                w.Write((double)s.Length);
                w.Write(s);
            }
        }

        public static void Test(TestCallback callback)
        {
            // TODO: Implement test and identify redmine

            callback(true);
        }
    }
}
