using com.dkhalife.apps.redmine.UWP.core;
using System;
using System.Reflection;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HubPage : Page
    {
        private string PageTitle = "";

        public HubPage()
        {
            this.InitializeComponent();
            NavigateSubPage(typeof(MyPage));
        }

        private void NavigateSubPage(Type page)
        {
            PageTitle = page.GetTypeInfo().GetCustomAttribute<PageAttribute>().Title;
            SubPage.Navigate(page);
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
            NavigateSubPage(typeof(Users));
        }

        private void Settings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavigateSubPage(typeof(Settings));
        }

        private async void Feedback_Tapped(object sender, TappedRoutedEventArgs e)
        {
            bool success = await Windows.System.Launcher.LaunchUriAsync(new Uri(@"windows-feedback://"));

            if (!success)
            {
                // URI launched
                throw new InvalidOperationException();
            }
        }

        private void Logout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // TOOD: Do logout logic
            Frame.Navigate(typeof(LoginPage));
        }
    }
}
