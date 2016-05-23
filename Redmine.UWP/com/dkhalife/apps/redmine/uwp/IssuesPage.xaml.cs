using LLM;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [Page("Issues")]
    public sealed partial class IssuesPage : Page
    {
        private string FilterDescription;
        private IssuesFilter Filter;

        public IssuesPage()
        {
            this.InitializeComponent();
        }

        private void OpenIssue(object sender, RoutedEventArgs e)
        {
            ListView list = sender as ListView;
            Issue i = list.SelectedItem as Issue;

            if (i != null)
            {
                Frame.Navigate(typeof(IssuePage), i.Id);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Filter = e.Parameter as IssuesFilter;

            if(Filter != null)
            {
                if(Filter.Project != null)
                {
                    FilterDescription = $"Showing issues for project {Filter.Project.Name}:";
                }
                else if (Filter.Query != null)
                {
                    FilterDescription = $"Showing issues for query {Filter.Query.Name}:";
                }
                else if (Filter.User != null)
                {
                    FilterDescription = $"Showing issues assigned to {Filter.User.Name}:";
                }
            }
            else
            {
                FilterDescription = "Showing all issues:";

                ObservableCollection<GroupedList> groups = new ObservableCollection<GroupedList>();

                var query = from issue in App.Client.Issues.Values
                            group issue by issue.Subject[0] into g
                            orderby g.Key
                            select new { GroupName = g.Key, Items = g };

                foreach (var g in query)
                {
                    GroupedList group = new GroupedList()
                    {
                        Key = g.GroupName
                    };

                    foreach (Issue issue in g.Items)
                    {
                        group.Add(issue);
                    }
                    groups.Add(group);
                }

                IssuesList.Source = groups;
            }
        }

        private void ItemSwipeTriggerComplete(object sender, SwipeCompleteEventArgs args)
        {
            Issue issue = (sender as LLMListViewItem).Content as Issue;
            if (args.SwipeDirection == SwipeDirection.Left)
            {
                // TODO: Mark completed
            }
            else
            {
                // TODO: Contact user
            }
        }
    }
}