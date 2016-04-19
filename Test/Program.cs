﻿using com.dkhalife.apps.redmine;
using com.dkhalife.apps.redmine.api;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            RedmineClient r = RedmineClient.Instance;
            r.Options.Port = 443;
            r.Options.Scheme = "https";
            r.Options.Host = "redmine.dkhalife.com";
            r.Options.ApiKey = "5bb2e06578c278195aab8a8be02d80dc6ca1df04";

            // TODO: Load the last updated


            Issues.Progress.Updated += Progress_Updated;
            Projects.Progress.Updated += Progress_Updated;
            Queries.Progress.Updated += Progress_Updated;
            TimeEntries.Progress.Updated += Progress_Updated;
            Users.Progress.Updated += Progress_Updated;

            Thread th = new Thread(new ThreadStart(async () =>
            {
                Console.WriteLine("Take 1");
                await r.SynchronizeAsync();
                Console.WriteLine("Take 2");
                await r.SynchronizeAsync();

                /*Console.WriteLine("Time Entry Activities");
                await r.UpdateTimeEntryActivitiesAsync();
                foreach(TimeEntryActivity a in r.TimeEntryActivities.Values)
                {
                    Console.WriteLine($"{a.Id} - {a.Name} - {a.IsDefault}");
                }
                Console.WriteLine("----------------------");

                Console.WriteLine("Issue Priorities");
                await r.UpdateIssuePrioritiesAsync();
                foreach (IssuePriority p in r.IssuePriorities.Values)
                {
                    Console.WriteLine($"{p.Id} - {p.Name} - {p.IsDefault}");
                }
                Console.WriteLine("----------------------");

                Console.WriteLine("Issue Statuses");
                await r.UpdateIssueStatusesAsync();
                foreach (IssueStatus s in r.IssueStatuses.Values)
                {
                    Console.WriteLine($"{s.Id} - {s.Name} - {s.IsClosed}");
                }
                Console.WriteLine("----------------------");

                Console.WriteLine("Trackers");
                await r.UpdateTrackersAsync();
                foreach (Tracker t in r.Trackers.Values)
                {
                    Console.WriteLine($"{t.Id} - {t.Name} - {t.DefaultStatus}");
                }
                Console.WriteLine("----------------------");
            
                Console.WriteLine("Queries");
                await r.UpdateQueriesAsync();
                foreach (Query q in r.Queries.Values)
                {
                    Console.WriteLine($"{q.Id} - {q.Name} - {q.ProjectId} - {q.IsPublic}");
                }
                Console.WriteLine("----------------------");

                Console.WriteLine("Time Entries");
                await r.UpdateTimeEntriesAsync();
                foreach (TimeEntry e in r.TimeEntries.Values)
                {
                    Console.WriteLine($"{e.Id} - {e.Activity} - {e.CreatedOn} - {e.Hours} - {e.Issue.Name} - {e.Project} - {e.SpentOn} - {e.UpdatedOn} - {e.User}");
                }
                Console.WriteLine("----------------------");

                Console.WriteLine("Projects");
                await r.UpdateProjectsAsync();
                foreach (Project p in r.Projects.Values)
                {
                    Console.WriteLine($"{p.Id} - {p.Name} - {p.Identifier} - {p.IsPublic} - {p.Parent} - {p.UpdatedOn}");
                }
                Console.WriteLine("----------------------");

                Console.WriteLine("Issues");
                await r.UpdateIssuesAsync();
                foreach (Issue i in r.Issues.Values)
                {
                    Console.WriteLine($"{i.Id} - {i.Subject}");
                }
                Console.WriteLine("----------------------");

                Console.WriteLine("Users");
                await r.UpdateUsersAsync();
                foreach (User u in r.Users.Values)
                {
                    Console.WriteLine($"{u.Id} - {u.FirstName} - {u.LastName} - {u.Email} - {u.CreatedOn} - {u.LastLoginOn}");
                }
                Console.WriteLine("----------------------");*/
            }));

            th.Start();
            th.Join();

            Console.ReadLine();
        }

        private static void Progress_Updated(object sender, double e)
        {
            Console.WriteLine($"{sender} - {e}%");
        }
    }
}
