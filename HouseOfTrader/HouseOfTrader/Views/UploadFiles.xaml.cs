using HouseOfTrader.ViewModels;
using Xamarin.Forms;

namespace HouseOfTrader.Views
{
    public partial class UploadFiles : ContentPage
    {
        public UploadFiles()
        {
            InitializeComponent();
            BindingContext = new UploadFileViewModel();
        }
    }
}
