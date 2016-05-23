using System;
using System.Reflection;
using Windows.Networking.Connectivity;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HubPage : Page
    {
        private SystemNavigationManager Navigation;
        public HubPage()
        {
            this.InitializeComponent();
            Navigation = SystemNavigationManager.GetForCurrentView();
            Navigation.BackRequested += Navigation_BackRequested;
            NavigateSubPage(typeof(MyPage));

            NetworkInformation.NetworkStatusChanged += NetworkStatusChange;
        }

        private async void NetworkStatusChange(object sender)
        {
            ConnectionProfile profile = NetworkInformation.GetInternetConnectionProfile();
            if(profile != null)
            {
                NetworkConnectivityLevel connection = profile.GetNetworkConnectivityLevel();
                if (connection == NetworkConnectivityLevel.InternetAccess)
                {
                    await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        // There is an active connection
                        QueriesButton.IsEnabled = true;
                    });

                    return;
                }
            }

            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                QueriesButton.IsEnabled = false;
                if (SubPage.Content.GetType() == typeof(QueriesPage))
                {
                    // TODO: Inapp toast feedback
                    NavigateSubPage(typeof(MyPage));
                }
            });
        }

        private void Navigation_BackRequested(object sender, BackRequestedEventArgs e)
        {
            SubPage.GoBack();
            PageTitle.Text = SubPage.Content.GetType().GetTypeInfo().GetCustomAttribute<PageAttribute>().Title;

            if (!SubPage.CanGoBack)
            {
                Navigation.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }

        private void NavigateSubPage(Type page, object parameter = null)
        {
            PageTitle.Text = page.GetTypeInfo().GetCustomAttribute<PageAttribute>().Title;

            if (page == typeof(MyPage))
            {
                MyPageButton.Visibility = Visibility.Collapsed;
                Navigation.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
            else
            {
                MyPageButton.Visibility = Visibility.Visible;
                Navigation.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            
            SubPage.Navigate(page, parameter);
            Menu.IsPaneOpen = false;
        }

        private void MenuButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Menu.IsPaneOpen = true;
        }

        private void MyPageButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavigateSubPage(typeof(MyPage)); ;
        }

        private void Projects_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavigateSubPage(typeof(ProjectsPage));
        }

        private void Issues_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavigateSubPage(typeof(IssuesPage));
        }

        private void Queries_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavigateSubPage(typeof(QueriesPage));
        }

        private void Users_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavigateSubPage(typeof(UsersPage));
        }

        private void Settings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavigateSubPage(typeof(SettingsPage));
        }

        private async void Feedback_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Menu.IsPaneOpen = false;

            // TODO: Figure out how to attach my app ID
            bool success = await Windows.System.Launcher.LaunchUriAsync(new Uri(@"windows-feedback://"));

            if (!success)
            {
                // TODO: Feedback
                throw new InvalidOperationException();
            }
        }

        private void Logout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // TOOD: Do logout logic
            Frame.Navigate(typeof(LoginPage));
        }

        public void OpenIssuesFor(Project project = null, Query query = null, User user = null)
        {
            NavigateSubPage(typeof(IssuesPage), new IssuesFilter() {
                Project = project,
                Query = query,
                User = user
            });
        }
    }
}
