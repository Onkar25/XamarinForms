using HouseOfTrader.Services.DatabaseService.DatabaseProvider;
namespace HouseOfTrader.Services.DatabaseService.BaseDatabaseModule
{
    public abstract class BaseDatabaseModule
    {

        #region Data Members
        public static IDatabaseServiceManager DatabaseServiceManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the BaseDatabaseModule class.
        /// </summary>
        protected BaseDatabaseModule()
        {
            DatabaseServiceManager = DatabaseProviders.Instance.DatabaseServiceManagerConnector;
        }
        #endregion
    }
}
