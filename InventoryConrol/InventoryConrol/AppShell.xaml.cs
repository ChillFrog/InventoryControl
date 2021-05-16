using Xamarin.Forms;

namespace InventoryConrol
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.InvenotryPage1), typeof(Views.InvenotryPage1));
        }
    }
}