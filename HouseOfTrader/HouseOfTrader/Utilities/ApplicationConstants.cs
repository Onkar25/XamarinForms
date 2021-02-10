using System;
using static HouseOfTrader.Utilities.EnumHelper;

namespace HouseOfTrader.Utilities
{
    public class ApplicationConstants
    {
        public ApplicationConstants()
        {
        }
        public static string AppVersion = string.Empty;
        public const string DatabaseKey = "DatabaseKey";
        public static string DatabasePath;
        public const string DatabaseName = "HouseOfTrader.db3";
        public static VersionCheck databaseVersionCheck = VersionCheck.First;
    }
}
