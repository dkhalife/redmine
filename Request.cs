using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimer
{
    class Request
    {
        public delegate void ResponseCallback(String response);

        private class State
        {
            public static int BUFFER_SIZE = 1024;

            public String url;
            public WebRequest request;
            public Stream stream;
            public byte[] buffer = new byte[BUFFER_SIZE];
            public Decoder decoder = Encoding.UTF8.GetDecoder();
            public StringBuilder result = new StringBuilder(String.Empty);
            public ResponseCallback callback;
        }

        public static void Get(string path, string param, ResponseCallback callback)
        {
            State s = new State();
            s.callback = callback;

            WebRequest r = s.request = WebRequest.Create(s.url = Config.LOCATION + path + (String.IsNullOrEmpty(param) ? "" : "?" + param));

            Console.Write(s.url);

            r.Method = "GET";
            r.ContentType = "application/json";
            r.Credentials = new NetworkCredential(Config.USERNAME, Config.PASSWORD);
            r.BeginGetResponse(new AsyncCallback(Process), s);
        }

        public static void Post(string path, string param, ResponseCallback callback)
        {
            State s = new State();
            s.callback = callback;

            WebRequest r = s.request = WebRequest.Create(s.url = Config.LOCATION + path);

            r.Method = "POST";
            r.ContentType = "application/json";
            r.Credentials = new NetworkCredential(Config.USERNAME, Config.PASSWORD);

            byte[] data = Encoding.UTF8.GetBytes(param);
            r.ContentLength = data.Length;

            Stream d = r.GetRequestStream();
            d.Write(data, 0, data.Length);
            d.Close();

            r.BeginGetResponse(new AsyncCallback(Process), s);
        }

        public static void Process(IAsyncResult result)
        {
            State s = result.AsyncState as State;
            try
            {
                WebResponse response = s.request.EndGetResponse(result);
                s.stream = response.GetResponseStream();
                s.stream.BeginRead(s.buffer, 0, State.BUFFER_SIZE, new AsyncCallback(ReadCallback), s);
            }
            catch (WebException e)
            {
                Console.WriteLine("WebException occurred, exception {0}", e);
                s.callback(null);
            }
        }

        public static void ReadCallback(IAsyncResult result)
        {
            State s = result.AsyncState as State;
            Stream responseStream = s.stream;

            int read = responseStream.EndRead(result);
            if (read > 0){
                Char[] buffer = new Char[read];
                int len = s.decoder.GetChars(s.buffer, 0, read, buffer, 0);
                String str = new String(buffer, 0, len);

                s.result.Append(Encoding.ASCII.GetString(s.buffer, 0, read));

                // Continue reading data until responseStream.EndRead returns –1.
                s.stream.BeginRead(s.buffer, 0, State.BUFFER_SIZE, new AsyncCallback(ReadCallback), s);
            }
            else
            {
                if (s.result.Length > 0)
                {
                    if (s.callback == null)
                        throw new Exception("Callback must be specified for all requests!");

                    s.callback(s.result.ToString());
                }

                s.stream.Close();
            }
        }
    }
}
