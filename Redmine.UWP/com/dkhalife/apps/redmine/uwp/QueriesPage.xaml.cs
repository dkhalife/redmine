using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.uwp
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
            ListView list = sender as ListView;
            Query query = list.SelectedItem as Query;
            App app = Application.Current as App;
            app.OpenIssuesFor(query: query);
        }
    }
}
