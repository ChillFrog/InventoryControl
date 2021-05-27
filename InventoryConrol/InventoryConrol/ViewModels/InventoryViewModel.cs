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
using InventoryConrol.Views;
using InventoryConrol.Services;

namespace InventoryConrol.ViewModels
{
    public class InventroyViewModel : BaseViewModel
    {

        public ObservableRangeCollection<Inventory> Invenotry { get; set; }
        public ObservableRangeCollection<Grouping<string, Inventory>> InventoryGroups { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Inventory> RemoveCommand { get; }
        public AsyncCommand<Inventory> AddCommand { get;}

        public InventroyViewModel()
        {
            Title = "Inventory Equipment";
            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand<Inventory>(Add);
            RemoveCommand = new AsyncCommand<Inventory>(Remove);
            Invenotry = new ObservableRangeCollection<Inventory>();
            //InventoryGroups.Add(new Grouping<string, Inventory>("Мебель", Invenotry.Take(2)));
            Invenotry.Add(new Inventory { Name = "Hello", AmountNeeded = "12", AmountScanned = "11" });

        }
        async Task Add(Inventory inventory)
        {
            await Shell.Current.GoToAsync($"{nameof(AddInventoryPage)}");
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
