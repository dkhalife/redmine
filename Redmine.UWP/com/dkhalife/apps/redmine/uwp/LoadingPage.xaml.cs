using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoadingPage : Page
    {
        public LoadingPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            api.Issues.Progress.Updating += Issues_Updating;
            api.Projects.Progress.Updating += Projects_Updating;
            api.Queries.Progress.Updating += Queries_Updating;
            api.TimeEntries.Progress.Updating += TimeEntries_Updating;
            api.Users.Progress.Updating += Users_Updating;

            await App.Client.SynchronizeAsync();

            Frame.Navigate(typeof(HubPage));
        }

        private void Users_Updating(object sender, int value)
        {
            CurrentTask.Text = "Updating users";
            CurrentProgress.Value = value;
        }

        private void TimeEntries_Updating(object sender, int value)
        {
            CurrentTask.Text = "Updating time entries";
            CurrentProgress.Value = value;
        }

        private void Queries_Updating(object sender, int value)
        {
            CurrentTask.Text = "Updating queries";
            CurrentProgress.Value = value;
        }

        private void Projects_Updating(object sender, int value)
        {
            CurrentTask.Text = "Updating projects";
            CurrentProgress.Value = value;
        }

        private void Issues_Updating(object sender, int value)
        {
            CurrentTask.Text = "Updating issues";
            CurrentProgress.Value = value;
        }
    }
}
