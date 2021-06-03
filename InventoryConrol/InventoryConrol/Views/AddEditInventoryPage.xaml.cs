using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryConrol.Services;
using InventoryConrol.Views;
using InventoryConrol.ViewModels;
using 
using InventoryConrol.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryConrol.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditInventoryPage : ContentPage
    {
        Inventory inventorydet;
        public AddEditInventoryPage(Inventory details)
        {
            InitializeComponent();
            if (details != null)
            {
                inventorydet = details;
                PopulateInventory(inventorydet);
            }
        }
        private void PopulateInventory(Inventory inventory)
        {
            name.Text = inventory.Name;
            amountneeded.Text = inventory.AmountNeeded;
            amountscanned.Text = inventory.AmountScanned;  
        }

        private void Savebtn_Clicked(object sender, EventArgs e)
        {

            bool res = DependencyService.Get<InventoryService>().UpdateInventory(inventorydet);
            if (res)
            {
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Message", "Data Failed To Update", "Ok");
            }
        }
    }
}