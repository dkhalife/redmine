using com.dkhalife.apps.redmine.api;
using com.dkhalife.apps.redmine.UWP;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IssuePage : Page
    {
        private Issue Issue;

        public IssuePage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            int? issue_id = e.Parameter as int?;

            if (issue_id != null && !App.Client.Issues.TryGetValue(issue_id.Value, out Issue))
            {
                Issue = await Issues.Get(issue_id.Value);

                if (Issue.Id == issue_id.Value)
                {
                    App.Client.Issues.Add(issue_id.Value, Issue);
                }
            }
        }
    }
}
