using System.Collections.Generic;
using HouseOfTrader.Models;

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
        List<MWPreOpenMarket> GetMWPreOpenMarket(string filename);
        List<BseSlb> GetBseSlb(string filename);
    }
}
