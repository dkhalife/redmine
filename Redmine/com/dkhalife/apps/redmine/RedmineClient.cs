using com.dkhalife.apps.redmine.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace com.dkhalife.apps.redmine
{
    public sealed class RedmineClient
    {
        #region Singleton
        private static volatile RedmineClient instance;
        private static object syncRoot = new Object();

        private RedmineClient(){}
        public static RedmineClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new RedmineClient();
                    }
                }

                return instance;
            }
        }
        #endregion

        #region Configuration
        public RedmineOptions Options { get; private set; } = new RedmineOptions();
        #endregion

        #region Redmine Properties
        public Dictionary<int, TimeEntryActivity> TimeEntryActivities { get; internal set; } = new Dictionary<int, TimeEntryActivity>();
        public Dictionary<int, IssuePriority> IssuePriorities { get; internal set; } = new Dictionary<int, IssuePriority>();
        public Dictionary<int, IssueStatus> IssueStatuses { get; internal set; } = new Dictionary<int, IssueStatus>();
        public Dictionary<int, Tracker> Trackers { get; internal set; } = new Dictionary<int, Tracker>();
        public Dictionary<int, Project> Projects { get; internal set; } = new Dictionary<int, Project>();
        public Dictionary<int, Issue> Issues { get; internal set; } = new Dictionary<int, Issue>();
        public Dictionary<int, Query> Queries { get; internal set; } = new Dictionary<int, Query>();
        public Dictionary<int, TimeEntry> TimeEntries { get; internal set; } = new Dictionary<int, TimeEntry>();
        public Dictionary<int, User> Users { get; internal set; } = new Dictionary<int, User>();
        #endregion

        #region API Core
        internal WebRequest CreateRequest(string path, string query = "")
        {
            UriBuilder uri = new UriBuilder(Options.Scheme, Options.Host, Options.Port, path, query);
            HttpWebRequest wr = HttpWebRequest.CreateHttp(uri.ToString());
            wr.Credentials = (Options.ApiKey != null) ? new NetworkCredential(Options.ApiKey, "") : new NetworkCredential(Options.Username, Options.Password);

            return wr;
        }

        internal WebRequest CreatePaginatedRequest(string path, PaginatedList page, string filter = "")
        {
            return CreateRequest(path, $"?offset={page.Offset}&limit={page.Limit}&{filter}" );
        }
        #endregion

        #region Update process
        private async Task<Boolean> UpdateTimeEntryActivitiesAsync()
        {
            return await api.TimeEntryActivities.Update(TimeEntryActivities);
        }

        private async Task<Boolean> UpdateIssuePrioritiesAsync()
        {
            return await api.IssuePriorities.Update(IssuePriorities);
        }

        private async Task<Boolean> UpdateIssueStatusesAsync()
        {
            return await api.IssueStatuses.Update(IssueStatuses);
        }

        private async Task<Boolean> UpdateTrackersAsync()
        {
            return await api.Trackers.Update(Trackers);
        }

        private async Task<Boolean> UpdateProjectsAsync(DateTime lastUpdated)
        {
            return await api.Projects.Update(Projects, lastUpdated);
        }

        private async Task<Boolean> UpdateIssuesAsync(DateTime lastUpdated)
        {
            return await api.Issues.Update(Issues, lastUpdated);
        }

        private async Task<Boolean> UpdateQueriesAsync()
        {
            return await api.Queries.Update(Queries);
        }

        private async Task<Boolean> UpdateTimeEntriesAsync(DateTime lastUpdated)
        {
            return await api.TimeEntries.Update(TimeEntries, lastUpdated);
        }

        private async Task<Boolean> UpdateUsersAsync()
        {
            return await api.Users.Update(Users);
        }

        private DateTime LastIssuesUpdate = DateTime.MinValue;
        private DateTime LastProjectsUpdate = DateTime.MinValue;
        private DateTime LastEnumerationsUpdate = DateTime.MinValue;

        public async Task<Boolean> SynchronizeAsync(bool ForceUpdate = false)
        {
            bool globalSuccess = true;

            if (ForceUpdate || LastEnumerationsUpdate < DateTime.Now.Subtract(Options.EnumerationsUpdateFrequency))
            {
                bool enumerationSuccess = true;

                enumerationSuccess &= await UpdateTimeEntryActivitiesAsync();
                enumerationSuccess &= await UpdateIssuePrioritiesAsync();
                enumerationSuccess &= await UpdateIssueStatusesAsync();
                enumerationSuccess &= await UpdateTrackersAsync();

                globalSuccess &= enumerationSuccess;

                if (enumerationSuccess)
                    LastEnumerationsUpdate = DateTime.Now;
            }

            if (ForceUpdate || LastProjectsUpdate < DateTime.Now.Subtract(Options.ProjectsUpdateFrequency))
            {
                bool projectsSuccess = true;

                projectsSuccess &= await UpdateProjectsAsync(LastProjectsUpdate);
                projectsSuccess &= await UpdateQueriesAsync();
                projectsSuccess &= await UpdateUsersAsync();

                globalSuccess &= projectsSuccess;

                if (projectsSuccess)
                    LastProjectsUpdate = DateTime.Now;
            }

            if (ForceUpdate || LastIssuesUpdate < DateTime.Now.Subtract(Options.UpdateFrequency))
            {
                bool issuesSuccess = true;

                issuesSuccess &= await UpdateIssuesAsync(LastIssuesUpdate);
                issuesSuccess &= await UpdateTimeEntriesAsync(LastIssuesUpdate);

                globalSuccess &= issuesSuccess;

                if (issuesSuccess)
                    LastIssuesUpdate = DateTime.Now;
            }
            
            return true;
        }
        #endregion
    }
}
