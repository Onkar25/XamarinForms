using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam4Demo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
    }
}