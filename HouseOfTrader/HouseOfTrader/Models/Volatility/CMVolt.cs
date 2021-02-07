using System;
namespace HouseOfTrader.Models
{
    public class CMVolt
    {
        public DateTime Date { get; set; }
        public string Symbol { get; set; }
        public double UnderlyingClosePriceA { get; set; }
        public double UnderlyingPreviousDayClosePriceB { get; set; }
        public double UnderlyingLogReturnsCLNAB { get; set; }
        public double PreviousDayUnderlyingVolatilityD { get; set; }
        public double CurrentDayUnderlyingDailyVolatilityE { get; set; }
        public double UnderlyingAnnualisedVolatilityF { get; set; }
    }
}
