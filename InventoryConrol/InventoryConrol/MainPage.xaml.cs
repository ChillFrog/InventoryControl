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

        async public void Btn1Classroom_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(InvenotryPage1)}");
        }
        async private void BtnEdit1Classroom_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Введите название","", initialValue:Btn1Classroom.Text, cancel: "Отмена");
            if (string.IsNullOrWhiteSpace(result) == false)
            {
                Btn1Classroom.Text = result;
            }
        }

        async private void BtnEdit2Classroom_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Введите название", "", initialValue: Btn2Classroom.Text,cancel:"Отмена");
            if (string.IsNullOrWhiteSpace(result) == false)
            {
                 Btn2Classroom.Text = result;
            }
        }

        async private void ExitToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}