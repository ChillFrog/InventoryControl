using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
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

        public void btn1Classroom_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.InvenotryPage1());
            BindingContext = new Views.InvenotryPage1();
        }
        async private void btnEdit1Classroom_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Введите название","", initialValue:btn1Classroom.Text);
            btn1Classroom.Text = result;
        }

        async private void btnEdit2Classroom_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Введите название", "", initialValue: btn2Classroom.Text,cancel:"Удалить");
            btn2Classroom.Text = result;
        }
    }
}