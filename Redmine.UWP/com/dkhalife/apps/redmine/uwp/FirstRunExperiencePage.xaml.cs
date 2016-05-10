using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FirstRunExperience : Page
    {
        public FirstRunExperience()
        {
            this.InitializeComponent();
        }
        
        private void GetStarted_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ApplicationData.Current.LocalSettings.Values["FirstRun"] = false;

            this.Frame.Navigate(typeof(LoginPage));
        }
    }
}
