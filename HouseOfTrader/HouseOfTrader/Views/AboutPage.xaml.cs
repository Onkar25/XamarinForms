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
            //await ReadFutureBhavCopy();
            //await ReadCashBhavCopy();
            //await ReadCMVolt();
            //await ReadCFInsiderTrading();
            //await ReadBulk();
            //await ReadCFPledgeData();
            //await ReadMWPreOpenMarket();
            await ReadBseSlb();
        }

        async Task ReadBseSlb()
        {
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file != null)
                {
                    MemoryStream fileStream = new MemoryStream(file.DataArray);
                    var products = DependencyService.Get<IFetchData>().GetBseSlb(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT : " + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }

        async Task ReadMWPreOpenMarket()
        {
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file != null)
                {
                    MemoryStream fileStream = new MemoryStream(file.DataArray);
                    var products = DependencyService.Get<IFetchData>().GetMWPreOpenMarket(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT : " + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }

        async Task ReadCFPledgeData()
        {
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file != null)
                {
                    MemoryStream fileStream = new MemoryStream(file.DataArray);
                    var products = DependencyService.Get<IFetchData>().GetCFPledgeData(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT : " + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }

        async Task ReadBulk()
        {
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file != null)
                {
                    MemoryStream fileStream = new MemoryStream(file.DataArray);
                    var products = DependencyService.Get<IFetchData>().GetBulkData(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT : " + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }

        async Task ReadCFInsiderTrading()
        {
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file != null)
                {
                    MemoryStream fileStream = new MemoryStream(file.DataArray);
                    var products = DependencyService.Get<IFetchData>().GetCFInsiderTrading(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT : " + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
        async Task ReadCMVolt()
        {
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file != null)
                {
                    MemoryStream fileStream = new MemoryStream(file.DataArray);
                    var products = DependencyService.Get<IFetchData>().GetCMVolt(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT : " + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
        async Task ReadCashBhavCopy()
        {
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file != null)
                {
                    MemoryStream fileStream = new MemoryStream(file.DataArray);
                    var products = DependencyService.Get<IFetchData>().GetCashBhavCopy(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT : " + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
        async Task ReadFutureBhavCopy()
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
                    Debug.WriteLine("TOTAL COUNT : " + res.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
    }
}