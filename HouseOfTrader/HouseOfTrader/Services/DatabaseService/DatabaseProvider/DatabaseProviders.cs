
using HouseOfTrader.Services.DatabaseService.DatabaseConnection;
using HouseOfTrader.Utilities;

namespace HouseOfTrader.Services.DatabaseService.DatabaseProvider
{
    public class DatabaseProviders
    {
        #region "Database Members"
        private static DatabaseProviders instance = null;

        private IDatabaseConnectivity databaseConnectivity = null;

        private IDatabaseConnectionManager databaseConnectionManager = null;

        private IDatabaseServiceManager databaseServiceManagerConnector = null;

        #endregion
        public DatabaseProviders()
        {
        }

        #region "Database Properites"
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static DatabaseProviders Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseProviders();
                }
                return instance;
            }
        }


        /// <summary>
        /// Gets the database connection manager.
        /// </summary>
        /// <returns>The database connection manager.</returns>
        private IDatabaseConnectionManager GetDatabaseConnectionManager()
        {
            if (this.databaseConnectionManager == null)
            {
                this.databaseConnectionManager = new DatabaseConectionManager(this.GetDatabaseConnectivity());
            }

            return this.databaseConnectionManager;
        }

        /// <summary>
        /// Gets the database connectivity.
        /// </summary>
        /// <returns>The database connectivity.</returns>
        private IDatabaseConnectivity GetDatabaseConnectivity()
        {
            if (this.databaseConnectivity == null)
            {
                //this.databaseConnectivity = DatabaseConnectivity.Instance;
            }

            return this.databaseConnectivity;
        }

        /// <summary>
        /// Gets or sets the database service manager connector.
        /// </summary>
        /// <value>The database service manager connector.</value>
        public IDatabaseServiceManager DatabaseServiceManagerConnector
        {
            get
            {
                if (this.databaseServiceManagerConnector == null)
                {
                    databaseServiceManagerConnector = new DatabaseServiceManager(GetDatabaseConnectionManager());
                }
                return this.databaseServiceManagerConnector;
            }

            set
            {
                this.databaseServiceManagerConnector = value;
            }
        }

        #endregion
    }
}
