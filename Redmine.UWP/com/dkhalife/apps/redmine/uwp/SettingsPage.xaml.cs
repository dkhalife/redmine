using com.dkhalife.apps.redmine.UWP.core;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [Page("Settings")]
    public sealed partial class Settings : Page {

        private RedmineOptions Server = RedmineClient.Instance.Options;

        public Settings()
        {
            this.InitializeComponent();

            // TODO: Auto update on change
        }
    }
}
