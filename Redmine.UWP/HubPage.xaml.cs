using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Redmine.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Hub : Page
    {
        private string PageTitle = "";

        public Hub()
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
            NavigateSubPage(typeof(Projects));
        }

        private void Issues_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavigateSubPage(typeof(Issues));
        }

        private void Queries_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavigateSubPage(typeof(Queries));
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
