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
using InventoryConrol.Views;

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
            Invenotry.Add(new Inventory { Name = "Hello", AmountNeeded = "12", AmountScanned = "11" });
        }
        async Task Add(Inventory inventory)
        {
            var route = $"{nameof(AddInventoryPage)}";
            await Shell.Current.GoToAsync ($"{nameof(AddInventoryPage)}");
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
