using LLM;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [Page("Projects")]
    public sealed partial class ProjectsPage : Page
    {
        public ProjectsPage()
        {
            this.InitializeComponent();

            ObservableCollection<GroupedList> groups = new ObservableCollection<GroupedList>();

            var query = from project in App.Client.Projects.Values
                        orderby project.Name
                        group project by char.ToUpper(project.Name[0]) into g
                        orderby g.Key
                        select new { GroupName = g.Key, Items = g };

            foreach (var g in query)
            {
                GroupedList group = new GroupedList()
                {
                    Key = g.GroupName
                };

                foreach (Project issue in g.Items)
                {
                    group.Add(issue);
                }
                groups.Add(group);
            }

            ProjectsList.Source = groups;
        }
        
        private void OpenIssuesForProject(object sender, RoutedEventArgs e)
        {
            ListView list = sender as ListView;
            Project project = list.SelectedItem as Project;
            App app = Application.Current as App;
            app.OpenIssuesFor(project: project);
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
