using com.dkhalife.apps.redmine.UWP.core;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [Page("My Page")]
    public sealed partial class IssuesPage : Page
    {
        private Dictionary<int, Issue> Issues = App.Client.Issues;

        public IssuesPage()
        {
            this.InitializeComponent();
        }
    }
}
