using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Plugin.FilePicker;
using Syncfusion.XlsIO;
using Xamarin.Forms;

namespace HouseOfTrader.Views
{
    public struct FutureBhavCopy
    {
        public string INSTRUMENT { get; set; }
        public string SYMBOL { get; set; }
        public DateTime EXPIRY_DT { get; set; }
        public float STRIKE_PR { get; set; }
        public string OPTION_TYP { get; set; }
        public float OPEN { get; set; }
        public float SETTLE_PR { get; set; }
        public long OPEN_INT { get; set; }
        public long CHG_IN_OI { get; set; }
        public DateTime TIMESTAMP { get; set; }
    }
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
                    using (ExcelEngine excelEngine = new ExcelEngine())
                    {

                        IApplication app = excelEngine.Excel;
                        app.DefaultVersion = ExcelVersion.Excel2016;
                        MemoryStream fileStream = new MemoryStream(file.DataArray);
                        IWorkbook workbook = excelEngine.Excel.Workbooks.Open(fileStream);
                        IWorksheet worksheet = workbook.Worksheets[0];
                        List<FutureBhavCopy> futureBhavCopys = new List<FutureBhavCopy>();
                        for (int i = 2; i < worksheet.Rows.Length; i++)// 
                        {
                            FutureBhavCopy futureBhavCopy = new FutureBhavCopy();
                            futureBhavCopy.INSTRUMENT = worksheet["A" + i].Text;
                            futureBhavCopy.SYMBOL = worksheet["B" + i].Text;
                            futureBhavCopy.EXPIRY_DT = DateTime.Parse(worksheet["C" + i].Text);
                            futureBhavCopy.STRIKE_PR = float.Parse(worksheet["D" + i].Text);
                            futureBhavCopy.OPTION_TYP = worksheet["E" + i].Text;
                            futureBhavCopy.OPEN = float.Parse( worksheet["F" + i].Text);
                            futureBhavCopy.SETTLE_PR = float.Parse(worksheet["J" + i].Text);
                            futureBhavCopy.OPEN_INT = long.Parse(worksheet["M" + i].Text);
                            futureBhavCopy.CHG_IN_OI = long.Parse(worksheet["N" + i].Text);
                            futureBhavCopy.TIMESTAMP = DateTime.Parse(worksheet["O" + i].Text);
                            futureBhavCopys.Add(futureBhavCopy);
                            Debug.WriteLine(i);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
        }
    }
}