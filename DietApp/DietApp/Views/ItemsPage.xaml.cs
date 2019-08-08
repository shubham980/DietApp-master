using DietApp.Models;
using DietApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DietApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage(string type)
        {

            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel(type);
        }

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel("Exercise");
        }

        /// <summary>
        /// Loads different pdf file according to name of clicked item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            if (item.Text == "Biceps")
                await Navigation.PushAsync(new ItemDetailPage("Finalbiceps.pdf"));
            else if (item.Text == "Chest")
                await Navigation.PushAsync(new ItemDetailPage("Finalchest.pdf"));
            else if (item.Text == "Vegan Diet")
                await Navigation.PushAsync(new ItemDetailPage("Vegandiet.pdf"));
            else if (item.Text == "Zone Diet")
                await Navigation.PushAsync(new ItemDetailPage("ZoneDiet.pdf"));
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}