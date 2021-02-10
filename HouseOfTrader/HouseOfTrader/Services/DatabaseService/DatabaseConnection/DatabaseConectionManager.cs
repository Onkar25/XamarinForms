using System;
using HouseOfTrader.Utilities;
using SQLite;

namespace HouseOfTrader.Services.DatabaseService.DatabaseConnection
{
    public class DatabaseConectionManager : IDatabaseConnectionManager
    {

        #region Data Members
        private IDatabaseConnectivity DatabaseConnectivity { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the DatabaseConectionManager" class.
        /// </summary>
        /// <param name="DatabaseConnectivity">Database connectivity.</param>
        public DatabaseConectionManager(IDatabaseConnectivity DatabaseConnectivity)
        {
            this.DatabaseConnectivity = DatabaseConnectivity;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the SQLite Database connection.
        /// </summary>
        /// <returns>The connection.</returns>
        public SQLiteConnection GetConnection()
        {
            try
            {
                return new SQLiteConnection(ApplicationConstants.DatabasePath);
            }
            catch (Exception ex)
            {
                throw new Exception("SQLiteConnection Exception : GetConnection() in DatabaseConectionManager class : " + ex.Message);
            }
        }
        #endregion
    }
}
