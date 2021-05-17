using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using InventoryConrol.Views;
using Xamarin.Forms.Xaml;

namespace InventoryConrol
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async public void btn1Classroom_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(InvenotryPage1)}");
        }
        async private void btnEdit1Classroom_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Введите название","", initialValue:btn1Classroom.Text, cancel: "Отмена");
            if (string.IsNullOrWhiteSpace(result) == false)
            {
                btn1Classroom.Text = result;
            }
        }

        async private void btnEdit2Classroom_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Введите название", "", initialValue: btn2Classroom.Text,cancel:"Отмена");
            if (string.IsNullOrWhiteSpace(result) == false)
            {
                 btn2Classroom.Text = result;
            }
        }

        private void ExitToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
            BindingContext = new LoginPage();
        }
    }
}