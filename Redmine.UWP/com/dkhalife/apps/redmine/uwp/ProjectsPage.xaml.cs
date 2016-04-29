using com.dkhalife.apps.redmine.UWP.core;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [Page("Projects")]
    public sealed partial class ProjectsPage : Page
    {
        private Dictionary<int, Project> Projects = App.Client.Projects;

        public ProjectsPage()
        {
            this.InitializeComponent();
        }
    }
}
