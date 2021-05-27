using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryConrol.ViewModels;
using InventoryConrol.Models;
using InventoryConrol.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryConrol.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddInventoryPage : ContentPage
    {
        public AddInventoryPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}