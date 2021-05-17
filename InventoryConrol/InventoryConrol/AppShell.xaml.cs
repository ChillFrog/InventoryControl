using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryConrol
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.InvenotryPage1), typeof(Views.InvenotryPage1));
            Routing.RegisterRoute(nameof(Views.LoginPage), typeof(Views.LoginPage));
            Routing.RegisterRoute(nameof(Views.RegistrationPage), typeof(Views.RegistrationPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
    }
}