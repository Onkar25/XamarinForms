﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HouseOfTrader.Services;
using Plugin.FilePicker;
using Xamarin.Forms;
namespace HouseOfTrader.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //await ReadFutureBhavCopy();
            //await ReadCashBhavCopy();
            //await ReadCMVolt();
            await ReadCFInsiderTrading();
        }

        private async Task ReadCFInsiderTrading()
        {
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file != null)
                {
                    MemoryStream fileStream = new MemoryStream(file.DataArray);
                    var products = DependencyService.Get<IFetchData>().GetCFInsiderTrading(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT" + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
        private async Task ReadCMVolt()
        {
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file != null)
                {
                    MemoryStream fileStream = new MemoryStream(file.DataArray);
                    var products = DependencyService.Get<IFetchData>().GetCMVolt(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT" + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
        private async Task ReadCashBhavCopy()
        {
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file != null)
                {
                    MemoryStream fileStream = new MemoryStream(file.DataArray);
                    var products = DependencyService.Get<IFetchData>().GetCashBhavCopy(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT" + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
        private async Task ReadFutureBhavCopy()
        {
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file != null)
                {
                    MemoryStream fileStream = new MemoryStream(file.DataArray);
                    var products = DependencyService.Get<IFetchData>().GetFutureBhavCopy(file.FilePath);
                    //FORMULA 
                    var res = from element in products
                              where element.INSTRUMENT == "FUTIDX" || element.INSTRUMENT == "FUTSTK"
                              group element by new
                              {
                                  element.INSTRUMENT,
                                  element.SYMBOL,
                                  element.OPTION_TYP
                              }
                              into groups
                              select groups.OrderBy(p => p.OPEN_INT).Take(2).ToList();
                    Debug.WriteLine("TOTAL COUNT" + res.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
    }
}