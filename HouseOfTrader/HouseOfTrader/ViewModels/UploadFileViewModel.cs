using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using HouseOfTrader.Views;
using Xamarin.Forms;

namespace HouseOfTrader.ViewModels
{
    public enum Categories
    {
        FutureBhavCopy,
        CashBhavCopy,
        BulkDeal,
        CFInsiderTrading,
        CFPledgeData,
        MWPreOpenMarket,
        BseSlb,
        CMVolt
    }
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public Categories CategoryType { get; set; }
    }
    public class UploadFileViewModel : INotifyPropertyChanged
    {
        List<Category> _CategoriesList;
        public List<Category> CategoriesList
        {
            get { return _CategoriesList; }
            set
            {
                _CategoriesList = value;
                OnPropertyChanged();
            }
        }

        bool _IsUploadButtonVisible;
        public bool IsUploadButtonVisible
        {
            get
            { return _IsUploadButtonVisible; }
            set
            {
                _IsUploadButtonVisible = value;
                OnPropertyChanged();
            }
        }

        bool _IsSaveEnable;
        public bool IsSaveEnable
        {
            get
            { return _IsSaveEnable; }
            set
            {
                _IsSaveEnable = value;
                OnPropertyChanged();
            }
        }

        bool _IsUploadLabelVisible;
        public bool IsUploadLabelVisible
        {
            get
            { return _IsUploadLabelVisible; }
            set
            {
                _IsUploadLabelVisible = value;
                OnPropertyChanged();
            }
        }

        string _UploadFilePath;
        public string UploadFilePath
        {
            get
            { return _UploadFilePath; }
            set
            {
                _UploadFilePath = value;
                OnPropertyChanged();
            }
        }
        bool _IsCategorySelected;
       
        Category _SelectedCategory;
        public Category SelectedCategory
        {
            get
            {
                return _SelectedCategory;
            }
            set
            {
                if (_SelectedCategory != value)
                {
                    _SelectedCategory = value;
                    _IsCategorySelected = true;
                    fileTypes.SaveCategory(_SelectedCategory.CategoryType);
                    OnPropertyChanged();
                }
            }
        }

        public ICommand UploadCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ResetCommand { get; set; }

        public IFileTypes fileTypes;
        public UploadFileViewModel()
        {
            CategoriesList = GetCategories();
            _IsUploadButtonVisible = true;
            _IsUploadLabelVisible = false;
            _IsSaveEnable = false;
         
            UploadCommand = new Command(async() => {
                UploadFilePath = await fileTypes.ReadFile();
                if (!string.IsNullOrEmpty(UploadFilePath))
                {
                    
                    if (_IsCategorySelected)
                    {
                        IsUploadButtonVisible = false;
                        IsUploadLabelVisible = true;
                        _IsSaveEnable = true;
                    }

                    else
                    {
                        IsUploadButtonVisible = true;
                        IsUploadLabelVisible = false;
                        _IsSaveEnable = false;
                    }
                }
                else
                {
                    IsUploadButtonVisible = true;
                    IsUploadLabelVisible = false;
                    _IsSaveEnable = false;
                }
            });
            SaveCommand = new Command(() => fileTypes.ReadFile());
            ResetCommand = new Command(() => { fileTypes.Reset() });
        }

        public List<Category> GetCategories()
        {
            List<Category> CategoriesList = new List<Category>();
            CategoriesList.Add(new Category { Id = 1, CategoryName = "Future Bhav Copy", CategoryType = Categories.FutureBhavCopy });
            CategoriesList.Add(new Category { Id = 2, CategoryName = "Cash Deal", CategoryType = Categories.CashBhavCopy });
            CategoriesList.Add(new Category { Id = 3, CategoryName = "Bulk Deal", CategoryType = Categories.BulkDeal });
            CategoriesList.Add(new Category { Id = 4, CategoryName = "CF Insider Trade", CategoryType = Categories.CFInsiderTrading });
            CategoriesList.Add(new Category { Id = 5, CategoryName = "CF Pledge Data", CategoryType = Categories.CFPledgeData });
            CategoriesList.Add(new Category { Id = 6, CategoryName = "MW Pre Open Market", CategoryType = Categories.MWPreOpenMarket });
            CategoriesList.Add(new Category { Id = 7, CategoryName = "Bse Slb", CategoryType = Categories.BseSlb });
            CategoriesList.Add(new Category { Id = 8, CategoryName = "CM Volt", CategoryType = Categories.CMVolt });
            return CategoriesList;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}