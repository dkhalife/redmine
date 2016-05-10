using System;
using System.Runtime.Serialization;

namespace com.dkhalife.apps.redmine
{
    [DataContract]
    public class RedmineSettings
    {
        [DataMember]
        public Uri Host { get; set; }

        [DataMember]
        public string Username { get; set; }
        [IgnoreDataMember]
        public string Password { get; set; }
        [IgnoreDataMember]
        public string ApiKey { get; set; }

        [DataMember]
        public TimeSpan UpdateFrequency { get; set; } = new TimeSpan(0, 15, 0);
        [DataMember]
        public TimeSpan ProjectsUpdateFrequency { get; set; } = new TimeSpan(1, 0, 0);
        [DataMember]
        public TimeSpan EnumerationsUpdateFrequency { get; set; } = new TimeSpan(1, 0, 0, 0);
    }
}