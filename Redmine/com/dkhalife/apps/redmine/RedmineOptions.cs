using System;

namespace com.dkhalife.apps.redmine
{
    public class RedmineOptions
    {
        public Uri Host { get; set; }
        public string Username { get; set; }
        public string Password { internal get; set; }
        public string ApiKey { internal get; set; }

        public TimeSpan UpdateFrequency { get; set; } = new TimeSpan(0, 15, 0);
        public TimeSpan ProjectsUpdateFrequency { get; set; } = new TimeSpan(1, 0, 0);
        public TimeSpan EnumerationsUpdateFrequency { get; set; } = new TimeSpan(1, 0, 0, 0);
    }
}