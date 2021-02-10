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
        void GetFileType();
        Task<string> ReadFile();
        void SaveFile();
        void Reset();
        void SaveCategory(Categories categories);
        void SetDate(DateTime dateTime);
    }
    public partial class UploadFiles : ContentPage, IFileTypes
    {
        Categories categories;
        UploadFileViewModel uploadFileViewModel;
        FileData file;
        public DateTime dateTime;
        public UploadFiles()
        {
            InitializeComponent();
            uploadFileViewModel = new UploadFileViewModel();
            uploadFileViewModel.fileTypes = this;
            BindingContext = uploadFileViewModel;
        }

        public void SetDate(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public void SaveFile()
        {
            // SAVE TO DATABASE
        }

        public void SaveCategory(Categories categories)
        {
            this.categories = categories;
        }

        public void Reset()
        {
            // RESET ALL FIELDS TO DEFAULT VALUE
        }

        public void GetFileType()
        {
            switch (categories)
            {
                case Categories.FutureBhavCopy:
                    ReadFutureBhavCopy();
                    break;
                case Categories.CashBhavCopy:
                    ReadCashBhavCopy();
                    break;
                case Categories.BulkDeal:
                    ReadBulk();
                    break;
                case Categories.CFInsiderTrading:
                    ReadCFInsiderTrading();
                    break;
                case Categories.CFPledgeData:
                    ReadCFPledgeData();
                    break;
                case Categories.MWPreOpenMarket:
                    ReadMWPreOpenMarket();
                    break;
                case Categories.BseSlb:
                    ReadBseSlb();
                    break;
                case Categories.CMVolt:
                    ReadCMVolt();
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