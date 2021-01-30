using System.Collections.Generic;
using HouseOfTrader.Models.BhavCopy;
using HouseOfTrader.Models.BulkDeal;
using HouseOfTrader.Models.InsiderTrade;
using HouseOfTrader.Models.InsiderTrade.PledgeData;
using HouseOfTrader.Models.Volatility;

namespace HouseOfTrader.Services
{
    public interface IFetchData
    {
        List<FutureBhavCopy> GetFutureBhavCopy(string filename);
        List<CashBhavCopy> GetCashBhavCopy(string filename);
        List<CMVolt> GetCMVolt(string filename);
        List<CFInsiderTrading> GetCFInsiderTrading(string filename);
        List<Bulk> GetBulkData(string filename);
        List<CFPledgeData> GetCFPledgeData(string filename);
    }
}
