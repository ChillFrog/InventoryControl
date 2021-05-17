using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmHelpers;
using System.Windows.Input;
using MvvmHelpers.Commands;
using InventoryConrol.Models;
using InventoryConrol.Services;

namespace InventoryConrol.ViewModels 
{
    public class MyInventoryViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Inventory> Invenotry { get; set; }
        public ObservableRangeCollection<Grouping<string, Inventory>> InventoryGroups { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Inventory> AddCommand { get; }
        public AsyncCommand<Inventory>RemoveCommand { get; }
      
        public MyInventoryViewModel()
        {

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand<Inventory>(Add);
            Invenotry = new ObservableRangeCollection<Inventory>();
            RemoveCommand = new AsyncCommand<Inventory>(Remove);
        }
        async Task Add(Inventory inventory)
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Name","");
            var roaster = await App.Current.MainPage.DisplayPromptAsync("Roaster","");
            await InventoryService.AddInventory(name, roaster);
            await Refresh();
        }
        async Task Remove(Inventory inventory)
        {
            await InventoryService.RemoveInventory(inventory.Id);
            await Refresh();
        }
        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            Invenotry.Clear();
            var inventories = await InventoryService.GetInventory();
            Invenotry.AddRange(inventories);
            IsBusy = false;
        }
    }
}
