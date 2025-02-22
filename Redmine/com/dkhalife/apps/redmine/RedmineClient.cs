﻿using com.dkhalife.apps.redmine.api;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
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

        public RedmineSettings Settings { get; set; } = null;

        public async Task<Boolean> TestConfiguration()
        {
            return IsReady = await api.Trackers.Update(Trackers);
        }
        #endregion

        #region Redmine Properties
        [DataMember]
        public ObservableDictionary<TimeEntryActivity> TimeEntryActivities { get; internal set; } = new ObservableDictionary<TimeEntryActivity> ();
        [DataMember]
        public ObservableDictionary<IssuePriority> IssuePriorities { get; internal set; } = new ObservableDictionary<IssuePriority>();
        [DataMember]
        public ObservableDictionary<IssueStatus> IssueStatuses { get; internal set; } = new ObservableDictionary<IssueStatus> ();
        [DataMember]
        public ObservableDictionary<Tracker> Trackers { get; internal set; } = new ObservableDictionary<Tracker> ();
        [DataMember]
        public ObservableDictionary<Project> Projects { get; internal set; } = new ObservableDictionary<Project> ();
        [DataMember]
        public ObservableDictionary<Issue> Issues { get; internal set; } = new ObservableDictionary<Issue> ();
        [DataMember]
        public ObservableDictionary<Query> Queries { get; internal set; } = new ObservableDictionary<Query> ();
        [DataMember]
        public ObservableDictionary<TimeEntry> TimeEntries { get; internal set; } = new ObservableDictionary<TimeEntry> ();
        [DataMember]
        public ObservableDictionary<User> Users { get; internal set; } = new ObservableDictionary<User> ();
        #endregion

        #region API Core
        internal WebRequest CreateRequest(string path, string query = "")
        {
            Uri host = Settings.Host;
            UriBuilder uri = new UriBuilder(host.Scheme, host.Host, host.Port, path, query);
            HttpWebRequest wr = HttpWebRequest.CreateHttp(uri.ToString());
            wr.Credentials = (!string.IsNullOrEmpty(Settings.ApiKey)) ? new NetworkCredential(Settings.ApiKey, "") : new NetworkCredential(Settings.Username, Settings.Password);

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

            if (ForceUpdate || LastEnumerationsUpdate < DateTime.Now.Subtract(Settings.EnumerationsUpdateFrequency))
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

            if (ForceUpdate || LastProjectsUpdate < DateTime.Now.Subtract(Settings.ProjectsUpdateFrequency))
            {
                bool projectsSuccess = true;

                projectsSuccess &= await UpdateProjectsAsync();
                projectsSuccess &= await UpdateQueriesAsync();
                projectsSuccess &= await UpdateUsersAsync();

                globalSuccess &= projectsSuccess;

                if (projectsSuccess)
                    LastProjectsUpdate = DateTime.Now;
            }

            if (ForceUpdate || LastIssuesUpdate < DateTime.Now.Subtract(Settings.UpdateFrequency))
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
