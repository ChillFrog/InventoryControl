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
        public AsyncCommand<Inventory> SearchForCommand { get; }

        public InventroyViewModel()
        {
            Title = "Inventory Equipment";
            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand<Inventory>(Add);
            RemoveCommand = new AsyncCommand<Inventory>(Remove);
            Invenotry = new ObservableRangeCollection<Inventory>();
            //InventoryGroups.Add(new Grouping<string, Inventory>("Мебель", Invenotry.Take(2)));

        }
        async Task Add(Inventory inventory)
        {

            var name = await App.Current.MainPage.DisplayPromptAsync("Название","", cancel: "отмена");
            var amountNeeded = await App.Current.MainPage.DisplayPromptAsync("Количество предметов", "", cancel: "отмена", keyboard: Keyboard.Numeric);
            var amountScanned = "0";
            if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(amountNeeded) || string.IsNullOrWhiteSpace(amountScanned))
            {
                return;
            }

            await InventoryService.AddInventory(name, amountNeeded, amountScanned);
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
