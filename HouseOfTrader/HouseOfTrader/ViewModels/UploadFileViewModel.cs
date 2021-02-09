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
        BhavCopy,
        BulkDeal,
        FII,
        InsiderTrade,
        PreOpenMarket,
        SLBSBhavCopy,
        Stock360FNOAnalysis,
        Volatility
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

        bool _IsSubCategoryEnable;
        public bool IsSubCategoryEnable
        {
            get
            { return _IsSubCategoryEnable; }
            set
            {
                _IsSubCategoryEnable = value;
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
                    switch (SelectedCategory.CategoryType)
                    {
                        case Categories.BhavCopy:
                        case Categories.Volatility:
                            IsSubCategoryEnable = true;
                        break;
                        case Categories.BulkDeal:
                        case Categories.FII:
                        case Categories.InsiderTrade:
                        case Categories.PreOpenMarket:
                        case Categories.SLBSBhavCopy:
                        case Categories.Stock360FNOAnalysis:
                            IsSubCategoryEnable = false;
                        break;
                        default:
                            IsSubCategoryEnable = false;
                        break;
                    }
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
            _IsSubCategoryEnable = true;
            _IsUploadButtonVisible = true;
            _IsUploadLabelVisible = false;
            _IsSaveEnable = false;
         
            UploadCommand = new Command(async() => {
                UploadFilePath = await fileTypes.ReadFile();
                if (!string.IsNullOrEmpty(UploadFilePath))
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
            });
            SaveCommand = new Command(() => fileTypes.ReadFile());
            ResetCommand = new Command(() => fileTypes.ReadFile());
        }

        public List<Category> GetCategories()
        {
            List<Category> CategoriesList = new List<Category>();
            CategoriesList.Add(new Category { Id = 1, CategoryName = "Bhav Copy", CategoryType = Categories.BhavCopy });
            CategoriesList.Add(new Category { Id = 2, CategoryName = "Bulk Deal", CategoryType = Categories.BulkDeal });
            CategoriesList.Add(new Category { Id = 3, CategoryName = "FII", CategoryType = Categories.FII });
            CategoriesList.Add(new Category { Id = 4, CategoryName = "Insider Trade", CategoryType = Categories.InsiderTrade });
            CategoriesList.Add(new Category { Id = 5, CategoryName = "Pre Open Market", CategoryType = Categories.PreOpenMarket });
            CategoriesList.Add(new Category { Id = 6, CategoryName = "SLBS Bhav Copy", CategoryType = Categories.SLBSBhavCopy });
            CategoriesList.Add(new Category { Id = 7, CategoryName = "Stock 360 FNO Analysis", CategoryType = Categories.Stock360FNOAnalysis });
            CategoriesList.Add(new Category { Id = 8, CategoryName = "Volatility", CategoryType = Categories.Volatility });
            return CategoriesList;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}