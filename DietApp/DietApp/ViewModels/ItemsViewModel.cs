using DietApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DietApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel(string type)
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(type));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"> Type of ItemsPage instan. We have Exercise and Diet. Different items get loaded according to it.</param>
        /// <returns></returns>

        async Task ExecuteLoadItemsCommand(string type)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = new List<Item>();
                if (type == "Exercise")
                {
                    var items1 = new List<Item>
                        {
                            new Item { Id = Guid.NewGuid().ToString(), Text = "Biceps", Description = "Biceps exercise instuctions." },
                            new Item { Id = Guid.NewGuid().ToString(), Text = "Chest", Description = "Chest exercise instructions." },
                        };
                    items = items1;
                }
                else if (type == "Diet")
                {
                    var items1 = new List<Item>
                        {
                            new Item { Id = Guid.NewGuid().ToString(), Text = "Vegan Diet", Description = "Vegan diet instructions." },
                            new Item { Id = Guid.NewGuid().ToString(), Text = "Zone Diet", Description = "Zone diet instructions." },
                        };
                    items = items1;
                }

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}