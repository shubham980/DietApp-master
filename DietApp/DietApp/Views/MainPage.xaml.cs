using DietApp.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DietApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Exercise, (NavigationPage)Detail);
        }

        /// <summary>
        /// Determines which page to load after clicking in the menu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Exercise:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage("Exercise")));
                        break;
                    case (int)MenuItemType.Diet:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage("Diet")));
                        break;
                    case (int)MenuItemType.Notes:
                        MenuPages.Add(id, new NavigationPage(new NotesPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}