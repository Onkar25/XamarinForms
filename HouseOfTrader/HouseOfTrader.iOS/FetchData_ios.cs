using System;
using System.Collections.Generic;
using System.IO;
using HouseOfTrader.iOS;
using HouseOfTrader.Models;
using HouseOfTrader.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FetchData_ios))]
namespace HouseOfTrader.iOS
{
    public class FetchData_ios : IFetchData
	{
        public FetchData_ios()
        {
        }

        public List<FutureBhavCopy> getProducts(string filename)
		{
			List<FutureBhavCopy> masters = new List<FutureBhavCopy>();

			using (StreamReader sr = new StreamReader(File.OpenRead(filename)))
			{
				string line1 = sr.ReadLine();
				string line = sr.ReadLine();
				while (line != null)
				{
					var data = line.Split(',');
					var obj = new FutureBhavCopy();
					obj.INSTRUMENT = data[0];
					obj.SYMBOL = data[1];
					obj.EXPIRY_DT = DateTime.Parse(data[2]);
					obj.STRIKE_PR = double.Parse(data[3]);
					obj.OPTION_TYP = data[4];
					obj.OPEN = double.Parse(data[5]);
					obj.HIGH = double.Parse(data[6]);
					obj.LOW = double.Parse(data[7]);
					obj.CLOSE = double.Parse(data[8]);
					obj.SETTLE_PR = double.Parse(data[9]);
					obj.CONTRACTS = double.Parse(data[10]);
					obj.VAL_INLAKH = double.Parse(data[11]);
					obj.OPEN_INT = double.Parse(data[12]);
					obj.CHG_IN_OI = double.Parse(data[13]);
                    obj.TIMESTAMP = DateTime.Parse(data[14]);
					obj.Filler1 = data[15];
					masters.Add(obj);
					line = sr.ReadLine();
				}
			}
			return masters;
		}
    }
}
