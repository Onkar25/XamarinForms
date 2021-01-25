using System;
namespace HouseOfTrader.Models.BhavCopy
{
    public struct FutureBhavCopy
    {
        public string INSTRUMENT { get; set; }
        public string SYMBOL { get; set; }
        public DateTime EXPIRY_DT { get; set; }
        public double STRIKE_PR { get; set; }
        public string OPTION_TYP { get; set; }
        public double OPEN { get; set; }
        public double HIGH { get; set; }
        public double LOW { get; set; }
        public double CLOSE { get; set; }
        public double SETTLE_PR { get; set; }
        public double CONTRACTS { get; set; }
        public double VAL_INLAKH { get; set; }
        public double OPEN_INT { get; set; }
        public double CHG_IN_OI { get; set; }
        public DateTime TIMESTAMP { get; set; }
        public string Filler1 { get; set; }
    }
}
