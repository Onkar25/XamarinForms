using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HouseOfTrader.Services;
using HouseOfTrader.Views;
using HouseOfTrader.Utilities;
using System.IO;
using HouseOfTrader.Services.DatabaseService.DatabaseProvider;
using static HouseOfTrader.Utilities.EnumHelper;
using Xamarin.Essentials;

namespace HouseOfTrader
{
    public partial class App : Application
    {

        public App()
        {
            var databaseVersion = Preferences.Get(ApplicationConstants.DatabaseKey, ApplicationConstants.AppVersion);
            if (string.IsNullOrEmpty(databaseVersion))
            {
                ApplicationConstants.databaseVersionCheck = VersionCheck.First;
            }
            else
            {
                if (ApplicationConstants.AppVersion == databaseVersion)
                {
                    ApplicationConstants.databaseVersionCheck = VersionCheck.Same;
                }
                else
                {
                    ApplicationConstants.databaseVersionCheck = VersionCheck.Updated;
                }
            }
            ApplicationConstants.DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3");
            DatabaseProviders.Instance.DatabaseServiceManagerConnector.CreateTable(ApplicationConstants.databaseVersionCheck);
            Preferences.Set(ApplicationConstants.DatabaseKey, ApplicationConstants.AppVersion);
            InitializeComponent();
            MainPage = new AppShell();
        }
        public void GetVersion()
        {
            ApplicationConstants.AppVersion = VersionTracking.CurrentVersion;
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
