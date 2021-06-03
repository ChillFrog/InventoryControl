using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using InventoryConrol.ViewModels;
using InventoryConrol.Models;
using Xamarin.Forms.Xaml;
using InventoryConrol.Services;

namespace InventoryConrol.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvenotryPage1 : ContentPage
    {
        public InvenotryPage1()
        {
            InitializeComponent();
        }

        private void EditInventory(object sender, ItemTappedEventArgs e)
        {
            Inventory details = e.Item as Inventory;
            if(details!=null)
            {
                Navigation.PushAsync(new AddEditInventoryPage(details));
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(HomePage)}");
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {

        }
    }
}