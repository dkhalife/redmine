using com.dkhalife.apps.redmine.api;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

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
        public bool IsReady { get; private set; } = false;

        public RedmineOptions Options { get; set; } = new RedmineOptions();

        public async Task<Boolean> TestConfiguration()
        {
            return IsReady = await api.Trackers.Update(Trackers);
        }
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
            Uri host = Options.Host;
            UriBuilder uri = new UriBuilder(host.Scheme, host.Host, host.Port, path, query);
            HttpWebRequest wr = HttpWebRequest.CreateHttp(uri.ToString());
            wr.Credentials = (!string.IsNullOrEmpty(Options.ApiKey)) ? new NetworkCredential(Options.ApiKey, "") : new NetworkCredential(Options.Username, Options.Password);

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
            if(IsReady)
                return await api.TimeEntryActivities.Update(TimeEntryActivities);

            return false;
        }

        private async Task<Boolean> UpdateIssuePrioritiesAsync()
        {
            if (IsReady)
                return await api.IssuePriorities.Update(IssuePriorities);

            return false;
        }

        private async Task<Boolean> UpdateIssueStatusesAsync()
        {
            if (IsReady)
                return await api.IssueStatuses.Update(IssueStatuses);

            return false;
        }

        private async Task<Boolean> UpdateTrackersAsync()
        {
            if (IsReady)
                return await api.Trackers.Update(Trackers);

            return false;
        }

        private async Task<Boolean> UpdateProjectsAsync()
        {
            if (IsReady)
                return await api.Projects.Update(Projects);

            return false;
        }

        private async Task<Boolean> UpdateIssuesAsync(DateTime lastUpdated)
        {
            if (IsReady)
                return await api.Issues.Update(Issues, lastUpdated);

            return false;
        }

        private async Task<Boolean> UpdateQueriesAsync()
        {
            if (IsReady)
                return await api.Queries.Update(Queries);

            return false;
        }

        private async Task<Boolean> UpdateTimeEntriesAsync()
        {
            if (IsReady)
                return await api.TimeEntries.Update(TimeEntries);

            return false;
        }

        private async Task<Boolean> UpdateUsersAsync()
        {
            if (IsReady)
                return await api.Users.Update(Users);

            return false;
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

                projectsSuccess &= await UpdateProjectsAsync();
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
                issuesSuccess &= await UpdateTimeEntriesAsync();

                globalSuccess &= issuesSuccess;

                if (issuesSuccess)
                    LastIssuesUpdate = DateTime.Now;
            }
            
            return true;
        }
        #endregion
    }
}
