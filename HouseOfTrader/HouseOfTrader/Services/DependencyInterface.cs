using System.Collections.Generic;
using HouseOfTrader.Models.BhavCopy;

namespace HouseOfTrader.Services
{
    public interface IFetchData
    {
        List<FutureBhavCopy> GetFutureBhavCopy(string filename);
        List<CashBhavCopy> GetCashBhavCopy(string filename);

    }
}
