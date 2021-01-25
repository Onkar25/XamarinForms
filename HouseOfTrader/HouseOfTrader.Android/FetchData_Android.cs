using System;
using System.Collections.Generic;
using System.IO;
using HouseOfTrader.Droid;
using HouseOfTrader.Models.BhavCopy;
using HouseOfTrader.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FetchData_Android))]
namespace HouseOfTrader.Droid
{
    public class FetchData_Android : IFetchData
    {
        public FetchData_Android()
        {
        }

        public List<CashBhavCopy> GetCashBhavCopy(string filename)
        {
            List<CashBhavCopy> masters = new List<CashBhavCopy>();

            using (StreamReader sr = new StreamReader(File.Open(filename, FileMode.Open)))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    var data = line.Split(',');
                    var obj = new CashBhavCopy
                    {
                        SYMBOL = data[0],
                        SERIES = data[1],
                        DATE1 = DateTime.Parse(data[2]),
                        PREV_CLOSE = double.Parse(data[3]),
                        OPEN_PRICE = double.Parse(data[4]),
                        HIGH_PRICE = double.Parse(data[5]),
                        LOW_PRICE = double.Parse(data[6]),
                        LAST_PRICE = double.Parse(data[7]),
                        CLOSE_PRICE = double.Parse(data[8]),
                        AVG_PRICE = double.Parse(data[9]),
                        TTL_TRD_QNTY = double.Parse(data[10]),
                        TURNOVER_LACS = double.Parse(data[11]),
                        NO_OF_TRADES = double.Parse(data[12]),
                        DELIV_QTY = double.Parse(data[13]),
                        DELIV_PER = double.Parse(data[14])
                    };
                    masters.Add(obj);
                    line = sr.ReadLine();
                }
            }
            return masters;
        }

        public List<FutureBhavCopy> GetFutureBhavCopy(string filename)
        {
            List<FutureBhavCopy> masters = new List<FutureBhavCopy>();
            
            using (StreamReader sr = new StreamReader(File.Open(filename,FileMode.Open)))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    var data = line.Split(',');
                    var obj = new FutureBhavCopy
                    {
                        INSTRUMENT = data[0],
                        SYMBOL = data[1],
                        EXPIRY_DT = DateTime.Parse(data[2]),
                        STRIKE_PR = double.Parse(data[3]),
                        OPTION_TYP = data[4],
                        OPEN = double.Parse(data[5]),
                        HIGH = double.Parse(data[6]),
                        LOW = double.Parse(data[7]),
                        CLOSE = double.Parse(data[8]),
                        SETTLE_PR = double.Parse(data[9]),
                        CONTRACTS = double.Parse(data[10]),
                        VAL_INLAKH = double.Parse(data[11]),
                        OPEN_INT = double.Parse(data[12]),
                        CHG_IN_OI = double.Parse(data[13]),
                        TIMESTAMP = DateTime.Parse(data[14]),
                        Filler1 = data[15]
                    };
                    masters.Add(obj);
                    line = sr.ReadLine();
                }
            }
            return masters;
        }
    }
}
