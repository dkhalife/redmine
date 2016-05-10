using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Security.Credentials;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace com.dkhalife.apps.redmine.UWP
{
    sealed partial class App : Application
    {
        public App()
        {
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session);

            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState != ApplicationExecutionState.Running && e.PreviousExecutionState != ApplicationExecutionState.Suspended)
                {
                    LoadAsync();
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    if (IsFirstRun)
                    {
                        rootFrame.Navigate(typeof(FirstRunExperience), e.Arguments);
                    }
                    else { 
                        if (Client.Settings == null)
                        {
                            rootFrame.Navigate(typeof(LoginPage), e.Arguments);
                        }
                        else
                        {
                            rootFrame.Navigate(typeof(HubPage), e.Arguments);
                        }
                    }
                }

                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SaveAsync();
            deferral.Complete();
        }

        internal static RedmineClient Client { get; private set; } = RedmineClient.Instance;

        private async Task<bool> SaveAsync()
        {
            // Save server settings
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("settings.json", CreationCollisionOption.ReplaceExisting);
            using (Stream outStream = await file.OpenStreamForWriteAsync())
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(RedmineSettings));
                json.WriteObject(outStream, Client.Settings);
            }

            // Save credentials
            PasswordVault vault = new PasswordVault();

            if (string.IsNullOrEmpty(Client.Settings.Username))
            {
                vault.Add(new PasswordCredential("Redmine", "ApiKey", Client.Settings.ApiKey));
            }
            else
            {
                vault.Add(new PasswordCredential("Redmine", Client.Settings.Username, Client.Settings.Password));
            }

            try
            {
                // Save server data
                IEnumerable<PropertyInfo> props = Client.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(XmlElementAttribute), false));
                foreach (PropertyInfo pi in props)
                {
                    file = await ApplicationData.Current.LocalFolder.CreateFileAsync($"{pi.Name}.json", CreationCollisionOption.ReplaceExisting);
                    using (Stream outStream = await file.OpenStreamForWriteAsync())
                    {
                        DataContractJsonSerializer json = new DataContractJsonSerializer(pi.PropertyType);
                        json.WriteObject(outStream, pi.GetValue(Client));
                    }
                }

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        private bool IsFirstRun = true;

        private async void LoadAsync()
        {
            // First run experience
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey("FirstRun"))
            {
                IsFirstRun = false;
            }

            // Load server settings
            IStorageItem file = await ApplicationData.Current.LocalFolder.TryGetItemAsync("settings.json");
            if (file != null)
            {

                try
                {
                    using (Stream inStream = await ((StorageFile)file).OpenStreamForReadAsync())
                    {
                        DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(RedmineSettings));
                        Client.Settings = json.ReadObject(inStream) as RedmineSettings;
                    }

                    if (Client.Settings != null)
                    {
                        // Load credentials 
                        PasswordVault vault = new PasswordVault();

                        if (string.IsNullOrEmpty(Client.Settings.Username))
                        {
                            PasswordCredential apiKey = vault.Retrieve("Redmine", "ApiKey");
                            Client.Settings.ApiKey = apiKey.Password;
                        }
                        else
                        {
                            PasswordCredential account = vault.Retrieve("Redmine", Client.Settings.Username);
                            Client.Settings.Password = account.Password;
                        }
                    }
                }
                catch
                {
                    // TODO: What can be done to prevent this
                }

                // Load server data
                if (Client.Settings != null)
                {
                    IEnumerable<PropertyInfo> props = Client.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(DataMemberAttribute), false));
                    foreach (PropertyInfo pi in props)
                    {
                        IStorageItem dataFile = await ApplicationData.Current.LocalFolder.TryGetItemAsync($"{pi.Name}.json");
                        if (dataFile != null)
                        {
                            try
                            {
                                using (Stream inStream = await ((StorageFile)file).OpenStreamForReadAsync())
                                {
                                    DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings()
                                    {
                                        UseSimpleDictionaryFormat = true
                                    };
                                    DataContractJsonSerializer json = new DataContractJsonSerializer(pi.PropertyType, settings);
                                    pi.SetValue(Client, json.ReadObject(inStream));
                                }
                            }
                            catch (Exception e)
                            {
                                // Corrupted file, remove it
                                //await dataFile.DeleteAsync();
                            }
                        }
                    }
                }
            }
        }
    }
}