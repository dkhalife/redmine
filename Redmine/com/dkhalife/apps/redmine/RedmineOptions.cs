using System;

namespace com.dkhalife.apps.redmine
{
    public class RedmineOptions
    {
        public string Scheme { get; set; } = "https";
        public int Port { get; set; } = 443;
        public string Host { get; set; } = "redmine.dkhalife.com";
        public string Username { get; set; } = "dany";
        public string Password { internal get; set; } = "$vs43AT80!";
        public string ApiKey { internal get; set; } /*= "5bb2e06578c278195aab8a8be02d80dc6ca1df04";*/

        public TimeSpan UpdateFrequency { get; set; } = new TimeSpan(0, 15, 0);
        public TimeSpan ProjectsUpdateFrequency { get; set; } = new TimeSpan(1, 0, 0);
        public TimeSpan EnumerationsUpdateFrequency { get; set; } = new TimeSpan(1, 0, 0, 0);
    }
}