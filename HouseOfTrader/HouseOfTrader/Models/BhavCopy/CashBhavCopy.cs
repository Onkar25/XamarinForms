using System;
namespace HouseOfTrader.Models
{
    public class CashBhavCopy
    {
        public string SYMBOL { get; set; }
        public string SERIES { get; set; }
        public DateTime DATE1 { get; set; }
        public double PREV_CLOSE { get; set; }
        public double OPEN_PRICE { get; set; }
        public double HIGH_PRICE { get; set; }
        public double LOW_PRICE { get; set; }
        public double LAST_PRICE { get; set; }
        public double CLOSE_PRICE { get; set; }
        public double AVG_PRICE { get; set; }
        public double TTL_TRD_QNTY { get; set; }
        public double TURNOVER_LACS { get; set; }
        public double NO_OF_TRADES { get; set; }
        public double DELIV_QTY { get; set; }
        public double DELIV_PER { get; set; }
    }
}
