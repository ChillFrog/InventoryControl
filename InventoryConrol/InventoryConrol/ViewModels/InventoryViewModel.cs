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

namespace InventoryConrol.ViewModels
{
    public class InventroyViewModel : BaseViewModel
    {

        public ObservableRangeCollection<Inventory> Invenotry { get; set; }
        public AsyncCommand RefreshCommand { get; }

        public InventroyViewModel()
        {
            Title = "Inventory Equipment";
            RefreshCommand = new AsyncCommand(Refresh);
            Invenotry = new ObservableRangeCollection<Inventory>();
            Invenotry.Add(new Inventory { Roaster = "2", Name = "Table", Image = "TableIcon.png" });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = "TableIcon.png" });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = "TableIcon.png" });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = "TableIcon.png" });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = "TableIcon.png" });
            Invenotry.Add(new Inventory { Roaster = "3", Name = "Table", Image = "TableIcon.png" });
        }
        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            Invenotry.Clear();
            LoadMore();
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
