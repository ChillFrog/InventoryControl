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

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        async private void MenuItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}