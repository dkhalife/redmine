using com.dkhalife.apps.redmine.UWP.core;
using System.Collections.Generic;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

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

        private void OpenContactCard(object sender, TappedRoutedEventArgs e)
        {
            User user = Contacts.SelectedItem as User;
            if(user == null)
            {
                // TODO: Log 
                return;
            }

            Contact card = new Contact()
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            card.Emails.Add(new ContactEmail()
            {
                Address = user.Email
            });

            e.Handled = true;

            ContactManager.ShowFullContactCard(card, new FullContactCardOptions()
            {
                DesiredRemainingView = 0
            });
        }

        private void OpenIssuesForUser(object sender, SelectionChangedEventArgs e)
        {
            User user = Contacts.SelectedItem as User;

            // TODO: Link to users page
        }
    }
}
