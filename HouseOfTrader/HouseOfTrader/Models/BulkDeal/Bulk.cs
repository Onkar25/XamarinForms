using System;
namespace HouseOfTrader.Models.BulkDeal
{
    public class Bulk
    {
        //public DateTime Date { get; set; }
        public string Date { get; set; }
        public string Symbol { get; set; }
        public string SecurityName { get; set; }
        public string ClientName { get; set; }
        public string BuySell { get; set; }
        public double QuantityTraded { get; set; }
        public double TradePriceWghtAvgPrice { get; set; }
        public string Remarks { get; set; }
        public double Filler1 { get; set; }
    }

}
