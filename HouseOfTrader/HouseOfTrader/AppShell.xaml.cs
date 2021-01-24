using System;
using System.Collections.Generic;
using HouseOfTrader.ViewModels;
using HouseOfTrader.Views;
using Xamarin.Forms;

namespace HouseOfTrader
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
