﻿using System;
using System.Collections.Generic;
using System.IO;
using HouseOfTrader.Droid;
using HouseOfTrader.Models.BhavCopy;
using HouseOfTrader.Models.Volatility;
using HouseOfTrader.Services;
using Xamarin.Forms;
[assembly: Dependency(typeof(FetchData_Android))]
namespace HouseOfTrader.Droid
{
    public class FetchData_Android : IFetchData
    {
        double DEFAULTDOUBLE = 0.0;
        public List<CashBhavCopy> GetCashBhavCopy(string filename)
        {
            List<CashBhavCopy> masters = new List<CashBhavCopy>();
            using (StreamReader sr = new StreamReader(File.Open(filename, FileMode.Open)))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    var data = line.Split(',');
                    var obj = new CashBhavCopy();
                    obj.SYMBOL = data[0];
                    obj.SERIES = data[1];
                    obj.DATE1 = DateTime.Parse(data[2]);
                    obj.PREV_CLOSE = Double.TryParse(data[3], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.OPEN_PRICE = Double.TryParse(data[4], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.HIGH_PRICE = Double.TryParse(data[5], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.LOW_PRICE = Double.TryParse(data[6], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.LAST_PRICE = Double.TryParse(data[7], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.CLOSE_PRICE = Double.TryParse(data[8], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.AVG_PRICE = Double.TryParse(data[9], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.TTL_TRD_QNTY = Double.TryParse(data[10], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.TURNOVER_LACS = Double.TryParse(data[11], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.NO_OF_TRADES = Double.TryParse(data[12], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.DELIV_QTY = Double.TryParse(data[13], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.DELIV_PER = Double.TryParse(data[14], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    masters.Add(obj);
                    line = sr.ReadLine();
                }
            }
            return masters;
        }
        public List<CMVolt> GetCMVolt(string filename)
        {
            List<CMVolt> masters = new List<CMVolt>();
            using (StreamReader sr = new StreamReader(File.Open(filename, FileMode.Open)))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    var data = line.Split(',');
                    var obj = new CMVolt();
                    obj.Date = DateTime.Parse(data[0]);
                    obj.Symbol = data[1];
                    obj.UnderlyingClosePriceA = Double.TryParse(data[2], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.UnderlyingPreviousDayClosePriceB = Double.TryParse(data[3], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.UnderlyingLogReturnsCLNAB = Double.TryParse(data[4], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.PreviousDayUnderlyingVolatilityD = Double.TryParse(data[5], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.CurrentDayUnderlyingDailyVolatilityE = Double.TryParse(data[6], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    obj.UnderlyingAnnualisedVolatilityF = Double.TryParse(data[7], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                    masters.Add(obj);
                    line = sr.ReadLine();
                }
            }
            return masters;
        }
        public List<FutureBhavCopy> GetFutureBhavCopy(string filename)
        {
            List<FutureBhavCopy> masters = new List<FutureBhavCopy>();
            using (StreamReader sr = new StreamReader(File.Open(filename, FileMode.Open)))
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