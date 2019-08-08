using DietApp.Views;
using System;
using System.IO;
using Xamarin.Forms;

namespace DietApp
{
    public partial class App : Application
    {
        public static string FolderPath { get; private set; }

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTI4OTczQDMxMzcyZTMyMmUzMEU3bVFPWlhuYWRrNzR6Z1g3cVRaSVBOZkZ1Uzk5T0pGeGE2Vk1iQkFnb0U9");

            InitializeComponent();

            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
