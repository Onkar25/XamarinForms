using System.Collections.Generic;
using HouseOfTrader.Models;

namespace HouseOfTrader.Services
{
    public interface IFetchData
    {
        List<FutureBhavCopy> getProducts(string filename);

    }
}
