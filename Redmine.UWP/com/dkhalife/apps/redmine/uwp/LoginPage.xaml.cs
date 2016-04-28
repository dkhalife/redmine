﻿using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace com.dkhalife.apps.redmine.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void Login_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Host.IsEnabled = false;
            Port.IsEnabled = false;
            Scheme.IsEnabled = false;
            Username.IsEnabled = false;
            Password.IsEnabled = false;
            ApiKey.IsEnabled = false;
            Login.IsEnabled = false;
            AutoLogin.IsEnabled = false;

            LoadingRing.IsActive = true;
            App.Client.Options = new RedmineOptions()
            {
                Host = Host.Text,
                Port = int.Parse(Port.Text),
                Scheme = Scheme.SelectedValue.ToString(),
                Username = Username.Text,
                Password = Password.Password,
                ApiKey = ApiKey.Text
            };

            bool success = await App.Client.TestConfiguration();
            if (success)
            {
                Frame.Navigate(typeof(LoadingPage));
            }
            else {
                // TODO: Output error

                LoadingRing.IsActive = false;

                Host.IsEnabled = true;
                Port.IsEnabled = true;
                Scheme.IsEnabled = true;
                Username.IsEnabled = true;
                Password.IsEnabled = true;
                ApiKey.IsEnabled = true;
                Login.IsEnabled = true;
                AutoLogin.IsEnabled = true;
            }
        }

        private void Profile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Update profile fields
        }
    }
}
