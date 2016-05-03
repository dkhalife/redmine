using com.dkhalife.apps.redmine.api;
using com.dkhalife.apps.redmine.UWP;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProjectPage : Page
    {
        private Project Project;

        public ProjectPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            int? project_id = e.Parameter as int?;

            if (project_id != null && !App.Client.Projects.TryGetValue(project_id.Value, out Project))
            {
                Project = await Projects.Get(project_id.Value);

                if (Project.Id == project_id.Value)
                {
                    App.Client.Projects.Add(project_id.Value, Project);
                }
            }
        }
    }
}
