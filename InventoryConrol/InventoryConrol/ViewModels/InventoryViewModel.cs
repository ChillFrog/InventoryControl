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
            var image = "http://pngimg.com/uploads/table/table_PNG7005.png";
            Invenotry = new ObservableRangeCollection<Inventory>();
            Invenotry.Add(new Inventory { Roaster = "2", Name = "Table", Image = image });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = image });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = image });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = image });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = image });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = image });
            //InventoryGroups.Add(new Grouping<string, Inventory>("Мебель", Invenotry.Take(2)));
            
        }
        async Task Add(Inventory inventory)
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Roaster");
            var roaster = await App.Current.MainPage.DisplayPromptAsync("Roaster", "Roaster");
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
        void LoadMore()
        {
            if (Invenotry.Count >= 10)
                return;
            Invenotry.Add(new Inventory { Roaster = "2", Name = "Table", Image = "TableIcon.png" });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = "TableIcon.png" });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = "TableIcon.png" });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = "TableIcon.png" });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = "TableIcon.png" });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = "TableIcon.png" });

        }
    }
}
