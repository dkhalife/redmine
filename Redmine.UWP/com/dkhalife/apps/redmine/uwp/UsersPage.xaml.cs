using com.dkhalife.apps.redmine.UWP.core;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [Page("Users")]
    public sealed partial class UsersPage : Page
    {
        private Dictionary<int, User> Users = App.Client.Users;

        public UsersPage()
        {
            this.InitializeComponent();
        }

        private void OpenContactCard(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {

        }
    }
}
