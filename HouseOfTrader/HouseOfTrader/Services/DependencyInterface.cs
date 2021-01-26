using System.Collections.Generic;
using HouseOfTrader.Models.BhavCopy;
using HouseOfTrader.Models.InsiderTrade;
using HouseOfTrader.Models.Volatility;

namespace HouseOfTrader.Services
{
    public interface IFetchData
    {
        List<FutureBhavCopy> GetFutureBhavCopy(string filename);
        List<CashBhavCopy> GetCashBhavCopy(string filename);
        List<CMVolt> GetCMVolt(string filename);
        List<CFInsiderTrading> GetCFInsiderTrading(string filename);

    }
}
