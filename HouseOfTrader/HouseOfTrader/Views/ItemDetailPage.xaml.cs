using System.ComponentModel;
using Xamarin.Forms;
using HouseOfTrader.ViewModels;

namespace HouseOfTrader.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}