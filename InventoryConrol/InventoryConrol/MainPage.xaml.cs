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
        async public void btnEdit1Classroom_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Введите название", "What's your name?", initialValue:btn1Classroom.Text);
            btn1Classroom.Text = result;
        }

        private void btnEdit2Classroom_Clicked(object sender, EventArgs e)
        {

        }
    }
}