using System;
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
            await ReadExcel();
        }
        public async Task ReadExcel()
        {
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file != null)
                {
                    MemoryStream fileStream = new MemoryStream(file.DataArray);
                    var products = DependencyService.Get<IFetchData>().getProducts(file.FilePath);
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