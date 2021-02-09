using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HouseOfTrader.Services;
using HouseOfTrader.ViewModels;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Xamarin.Forms;
namespace HouseOfTrader.Views
{
    public interface IFileTypes
    {
        void GetFileType(Categories categories);
        Task<string> ReadFile();
    }
    public partial class UploadFiles : ContentPage, IFileTypes
    {
        UploadFileViewModel uploadFileViewModel;
        FileData file;
        public UploadFiles()
        {
            InitializeComponent();
            uploadFileViewModel = new UploadFileViewModel();
            uploadFileViewModel.fileTypes = this;
            BindingContext = uploadFileViewModel;
        }
        public void GetFileType(Categories categories)
        {
            switch (categories)
            {
                case Categories.BhavCopy:
                    ReadCashBhavCopy();
                    break;
                case Categories.BulkDeal:
                    break;
                case Categories.FII:
                    break;
                case Categories.InsiderTrade:
                    break;
                case Categories.PreOpenMarket:
                    break;
                case Categories.SLBSBhavCopy:
                    break;
                case Categories.Stock360FNOAnalysis:
                    break;
                case Categories.Volatility:
                    break;
                default:
                    break;
            }
        }
        public async Task<string> ReadFile()
        {
            file = await CrossFilePicker.Current.PickFile();
            if (file != null)
            {
                return file.FileName;
            }
            return string.Empty;
            }
        void ReadBseSlb()
        {
            try
            {
                if (file != null)
                {
                    var products = DependencyService.Get<IFetchData>().GetBseSlb(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT : " + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
        void ReadMWPreOpenMarket()
        {
            try
            {
                if (file != null)
                {
                    var products = DependencyService.Get<IFetchData>().GetMWPreOpenMarket(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT : " + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
        void ReadCFPledgeData()
        {
            try
            {
                if (file != null)
                {
                    var products = DependencyService.Get<IFetchData>().GetCFPledgeData(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT : " + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
        void ReadBulk()
        {
            try
            {
                if (file != null)
                {
                    var products = DependencyService.Get<IFetchData>().GetBulkData(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT : " + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
        void ReadCFInsiderTrading()
        {
            try
            {
                if (file != null)
                {
                    var products = DependencyService.Get<IFetchData>().GetCFInsiderTrading(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT : " + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
        void ReadCMVolt()
        {
            try
            {
                if (file != null)
                {
                    var products = DependencyService.Get<IFetchData>().GetCMVolt(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT : " + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
        void ReadCashBhavCopy()
        {
            try
            {
                if (file != null)
                {
                    var products = DependencyService.Get<IFetchData>().GetCashBhavCopy(file.FilePath);
                    Debug.WriteLine("TOTAL COUNT : " + products.Count());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
        void ReadFutureBhavCopy()
        {
            try
            {
                if (file != null)
                {
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