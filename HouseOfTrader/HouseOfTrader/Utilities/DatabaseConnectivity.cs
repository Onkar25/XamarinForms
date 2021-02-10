using System;
using System.IO;

namespace HouseOfTrader.Utilities
{
    public class DatabaseConnectivity : IDatabaseConnectivity
    {
        private static DatabaseConnectivity databaseConnectivity;

        /// <summary>
        /// Gets the instance of DatabaseConnectivity.
        /// </summary>
        /// <value>The current instance.</value>
        public static DatabaseConnectivity Instance
        {
            get
            {
                if (databaseConnectivity == null)
                {
                    databaseConnectivity = new DatabaseConnectivity();
                }
                return databaseConnectivity;
            }
        }

        /// <summary>
        /// Gets Database path.
        /// </summary>
        /// <returns>Database path.</returns>
        public string GetDatabasePath()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                        ApplicationConstants.DatabaseName);

            return path;
        }
    }
}
