using System;
namespace HouseOfTrader.Models
{
    public class BseSlb
    {
        public string Segment { get; set; }
        public string Txn_Date { get; set; }
        public double SLB_Code { get; set; }
        public string SLB_Symbol { get; set; }
        public double Cash_Code { get; set; }
        public string Cash_Symbol { get; set; }
        public string Scrip_Name { get; set; }
        public DateTime Expiry_Date { get; set; }
        public string FC_Type { get; set; }
        public string ISIN_Code { get; set; }
        public double Open_Price { get; set; }
        public double High_Price { get; set; }
        public double Low_Price { get; set; }
        public double Close_Price { get; set; }
        public double No_of_Trades { get; set; }
        public double Total_Quantity { get; set; }
        public double Net_Turnover { get; set; }
        public double Cash_PDCP { get; set; }
        public double Underlying_Value { get; set; }
        public double Cash_TDCP { get; set; }
        public double Avg_Qty_Per_Txn { get; set; }
        public double Avg_LFee_Per_Share { get; set; }
        public double Annualized_Yield { get; set; }
        public string Filler02 { get; set; }
        public string Filler03 { get; set; }
        public string Filler04 { get; set; }
        public string Filler05 { get; set; }
    }
}
