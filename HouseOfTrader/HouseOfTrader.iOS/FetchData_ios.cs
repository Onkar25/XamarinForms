﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using HouseOfTrader.iOS;
using HouseOfTrader.Models;
using HouseOfTrader.Services;
using Xamarin.Forms;
[assembly: Dependency(typeof(FetchData_ios))]
namespace HouseOfTrader.iOS
{
    public class FetchData_ios : IFetchData
    {
        double DEFAULTDOUBLE = 0.0;

        public List<CFPledgeData> GetCFPledgeData(string filename)
        {
            List<CFPledgeData> masters = new List<CFPledgeData>();
            try
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(filename)))
                {
                    string line1 = sr.ReadLine();
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        var data = line.Split(',');
                        var obj = new CFPledgeData();
                        obj.NAMEOFCOMPANY = data[0];
                        obj.TOTALNOOFISSUEDSHARESABC = Double.TryParse(data[1], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.TOTALPROMOTERHOLDINGNOOFSHARESA = Double.TryParse(data[2], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.TOTALPROMOTERHOLDINGAABC = data[3];
                        obj.TOTALPUBLICHOLDINGB = Double.TryParse(data[4], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.PROMOTERSHARESENCUMBEREDASOFLASTQUARTERNOOFSHARESX = data[5];
                        obj.PROMOTERSHARESENCUMBEREDASOFLASTQUARTEROFPROMOTERSHARESXA = data[6];
                        obj.PROMOTERSHARESENCUMBEREDASOFLASTQUARTEROFTOTALSHARESXABC = data[7];
                        //obj.DISCLOSUREMADEBYPROMOTERS = DateTime.Parse(data[8]);
                        obj.DISCLOSUREMADEBYPROMOTERS = data[8];
                        obj.NOOFSHARESPLEDGEDINTHEDEPOSITORYSYSTEMNOOFSHARESPLEDGED = data[9];
                        obj.NOOFSHARESPLEDGEDINTHEDEPOSITORYSYSTEMTOTALNOOFDEMATSHARES = data[10];
                        obj.PLEDGEDEMAT = data[11];
                        masters.Add(obj);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
            return masters;
        }


        public List<Bulk> GetBulkData(string filename)
        {
            List<Bulk> masters = new List<Bulk>();
            try
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(filename)))
                {
                    string line1 = sr.ReadLine();
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        var data = line.Split(',');
                        var obj = new Bulk();
                        obj.Date = data[0];
                        obj.Symbol = data[1];
                        obj.SecurityName = data[2];
                        obj.ClientName = data[3];
                        obj.BuySell = data[4];
                        obj.QuantityTraded = Double.TryParse(data[5], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.TradePriceWghtAvgPrice = Double.TryParse(data[6], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.Remarks = data[7];
                        //obj.Filler1 = Double.TryParse(data[8], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        masters.Add(obj);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
            return masters;
        }

        public List<CashBhavCopy> GetCashBhavCopy(string filename)
        {
            List<CashBhavCopy> masters = new List<CashBhavCopy>();
            try
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(filename)))
                {
                    string line1 = sr.ReadLine();
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
            return masters;
        }

        public List<CFInsiderTrading> GetCFInsiderTrading(string filename)
        {
            List<CFInsiderTrading> masters = new List<CFInsiderTrading>();
            try
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(filename)))
                {
                    string line1 = sr.ReadLine();
                    string line = sr.ReadLine();
                    int i = 0;
                    while (line != null)
                    {
                        var data = line.Split(',');
                        var obj = new CFInsiderTrading();
                        obj.SYMBOL = data[0];
                        obj.COMPANY = data[1];
                        obj.REGULATION = data[2];
                        obj.NAMEOFTHEACQUIRERDISPOSER = data[3];
                        obj.CATEGORYOFPERSON = data[4];
                        obj.TYPEOFSECURITYPRIOR = data[5];
                        obj.NOOFSECURITYPRIOR = data[6];
                        obj.SHAREHOLDINGPRIOR = Double.TryParse(data[7], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.TYPEOFSECURITYACQUIREDDISPLOSED = data[8];
                        obj.NOOFSECURITIESACQUIREDDISPLOSED = Double.TryParse(data[9], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.VALUEOFSECURITYACQUIREDDISPLOSED = data[10];
                        obj.ACQUISITIONDISPOSALTRANSACTIONTYPE = data[11];
                        obj.TYPEOFSECURITYPOST = data[12];
                        obj.NOOFSECURITYPOST = data[13];
                        obj.POST = data[14];
                        obj.DATEOFALLOTMENTACQUISITIONFROM = data[15];
                        obj.DATEOFALLOTMENTACQUISITIONTO = data[16];
                        obj.DATEOFINITMATIONTOCOMPANY = data[17];
                        obj.MODEOFACQUISITION = data[18];
                        obj.DERIVATIVETYPESECURITY = data[19];
                        obj.DERIVATIVECONTRACTSPECIFICATION = data[20];
                        obj.NOTIONALVALUEBUY = Double.TryParse(data[21], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.NUMBEROFUNITSCONTRACTLOTSIZEBUY = Double.TryParse(data[22], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.NOTIONALVALUESELL = Double.TryParse(data[23], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.NUMBEROFUNITSCONTRACTLOTSIZESELL = Double.TryParse(data[24], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.EXCHANGE = data[25];
                        obj.REMARK = data[26];
                        obj.BROADCASTEDATEANDTIME = data[27];
                             //DateTime.Parse(data[27]);
                        obj.XBRL = data[28];
                        masters.Add(obj);
                        Debug.WriteLine(i++);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
            return masters;
        }

        
        public List<CMVolt> GetCMVolt(string filename)
        {
            List<CMVolt> masters = new List<CMVolt>();
            try
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(filename)))
                {
                    string line1 = sr.ReadLine();
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
            return masters;
        }
        public List<FutureBhavCopy> GetFutureBhavCopy(string filename)
        {
            List<FutureBhavCopy> masters = new List<FutureBhavCopy>();
            try
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(filename)))
                {
                    string line1 = sr.ReadLine();
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        var data = line.Split(',');
                        var obj = new FutureBhavCopy();
                        obj.INSTRUMENT = data[0];
                        obj.SYMBOL = data[1];
                        obj.EXPIRY_DT = DateTime.Parse(data[2]);
                        obj.STRIKE_PR = Double.TryParse(data[3], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.OPTION_TYP = data[4];
                        obj.OPEN = Double.TryParse(data[5], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.HIGH = Double.TryParse(data[6], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.LOW = Double.TryParse(data[7], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.CLOSE = Double.TryParse(data[8], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.SETTLE_PR = Double.TryParse(data[9], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.CONTRACTS = Double.TryParse(data[10], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.VAL_INLAKH = Double.TryParse(data[11], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.OPEN_INT = Double.TryParse(data[12], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.CHG_IN_OI = Double.TryParse(data[13], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.TIMESTAMP = DateTime.Parse(data[14]);
                        obj.Filler1 = data[15];
                        masters.Add(obj);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
            return masters;
        }

        public List<MWPreOpenMarket> GetMWPreOpenMarket(string filename)
        {
            List<MWPreOpenMarket> masters = new List<MWPreOpenMarket>();
            try
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(filename)))
                {
                    string line1 = sr.ReadLine();
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        var data = line.Split(',');
                        var obj = new MWPreOpenMarket();
                        obj.SYMBOL = data[0];
                        obj.PREVCLOSE = Double.TryParse(data[1], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.IEPPRICE = Double.TryParse(data[2], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.CHNG = Double.TryParse(data[3], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.CHNG1 = Double.TryParse(data[4], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.FINALPRICE = Double.TryParse(data[5], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.FINALQUANTITY = Double.TryParse(data[6], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.VALUE = data[7];
                        obj.FFMCAP = data[8];
                        obj.NM52WH = data[9];
                        obj.NM52WL = Double.TryParse(data[10], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        
                        masters.Add(obj);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
            return masters;
        }

        public List<BseSlb> GetBseSlb(string filename)
        {
            List<BseSlb> masters = new List<BseSlb>();
            try
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(filename)))
                {
                    string line1 = sr.ReadLine();
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        var data = line.Split(',');
                        var obj = new BseSlb();
                        obj.Segment = data[0];
                        obj.Txn_Date = data[1];
                        obj.SLB_Code = Double.TryParse(data[2], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.SLB_Symbol = data[3];
                        obj.Cash_Code = Double.TryParse(data[4], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.Cash_Symbol = data[5];
                        obj.Scrip_Name = data[6];
                        obj.Expiry_Date = DateTime.Parse(data[7]);
                        obj.FC_Type = data[8];
                        obj.ISIN_Code = data[9];
                        obj.Open_Price = Double.TryParse(data[10], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.High_Price = Double.TryParse(data[11], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.Low_Price = Double.TryParse(data[12], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.Close_Price = Double.TryParse(data[13], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.No_of_Trades = Double.TryParse(data[14], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.Total_Quantity = Double.TryParse(data[15], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.Net_Turnover = Double.TryParse(data[16], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.Cash_PDCP = Double.TryParse(data[17], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.Underlying_Value = Double.TryParse(data[18], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.Cash_TDCP = Double.TryParse(data[19], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.Avg_Qty_Per_Txn = Double.TryParse(data[20], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.Avg_LFee_Per_Share = Double.TryParse(data[21], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.Annualized_Yield = Double.TryParse(data[22], out DEFAULTDOUBLE) ? DEFAULTDOUBLE : DEFAULTDOUBLE;
                        obj.Filler02 = data[23];
                        obj.Filler03 = data[24];
                        obj.Filler04 = data[25];
                        obj.Filler05 = data[26];
                        masters.Add(obj);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
            }
            return masters;
        }
    }
}