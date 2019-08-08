using DietApp.Models;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace DietApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;

        /// <summary>
        /// Creates the menu items and add those to the view
        /// </summary>

        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Exercise, Title="Exercise" },
                new HomeMenuItem {Id = MenuItemType.Diet, Title="Diet" },
                new HomeMenuItem {Id = MenuItemType.Notes, Title="Notes" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}