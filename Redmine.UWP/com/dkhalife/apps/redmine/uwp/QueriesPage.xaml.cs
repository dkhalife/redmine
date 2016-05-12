using com.dkhalife.apps.redmine.UWP.core;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [Page("Queries")]
    public sealed partial class QueriesPage : Page
    {
        private Dictionary<int, Query> Queries = App.Client.Queries;

        public QueriesPage()
        {
            this.InitializeComponent();
        }

        private void OpenIssuesForQuery(object sender, SelectionChangedEventArgs e)
        {
            Query query = (QueriesList.SelectedItem) as Query;
            if (query == null) {
                return;
            }

            // TODO: Link to issues page
        }
    }
}
