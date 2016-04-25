using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public Hub()
        {
            this.InitializeComponent();
            PageTitle.Text = "My Page";
            SubPage.Navigate(typeof(MyPage));
        }

        private void MenuButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Menu.IsPaneOpen = true;
        }

        private void MyPageButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageTitle.Text = "My Page";
            SubPage.Navigate(typeof(MyPage));
        }

        private void Projects_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageTitle.Text = "Projects";
            SubPage.Navigate(typeof(Projects));
        }

        private void Issues_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageTitle.Text = "Issues";
            SubPage.Navigate(typeof(Issues));
        }

        private void Queries_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageTitle.Text = "Queries";
            SubPage.Navigate(typeof(Queries));
        }

        private void Users_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageTitle.Text = "Users";
            SubPage.Navigate(typeof(Users));
        }

        private void Settings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageTitle.Text = "Settings";
            SubPage.Navigate(typeof(Settings));
        }

        private void Logout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Todo: implement logout
            throw new NotImplementedException();
        }
    }
}
