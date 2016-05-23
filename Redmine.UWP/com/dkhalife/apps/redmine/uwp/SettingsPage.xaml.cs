using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [Page("Settings")]
    public sealed partial class SettingsPage : Page {

        private RedmineSettings Server = RedmineClient.Instance.Settings;

        public SettingsPage()
        {
            this.InitializeComponent();

            if(string.IsNullOrEmpty(Server.Username) && !string.IsNullOrWhiteSpace(Server.ApiKey))
            {
                AuthenticationMethod.SelectedIndex = 1;
            }
        }

        private void AuthenticationMethodChanged(object sender, SelectionChangedEventArgs e)
        {
            Username.Text = Password.Password = ApiKey.Text = "";
        }

        private void SettingChanged(object sender, TextChangedEventArgs e)
        {
            FrameworkElement ui = (FrameworkElement)sender;
            switch (ui.Name)
            {
                case "Host":
                    Uri host;
                    Uri.TryCreate(((TextBox)ui).Text, UriKind.Absolute, out host);
                    Server.Host = host;
                    break;

                case "Username":
                    Server.Username = ((TextBox)ui).Text;
                    break;
                    
                case "ApiKey":
                    Server.ApiKey = ((TextBox)ui).Text;
                    break;
            }
            
            // TODO: Autosave
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            Server.Password = ((PasswordBox) sender).Password;

            // TODO: Autosave
        }

        private async void TestConfiguration(object sender, TappedRoutedEventArgs e)
        {
            if (await App.Client.TestConfiguration())
                TestOutcome.Text = "Connection successful";
            else
                TestOutcome.Text = "Connetion failed";
        }
    }
}
