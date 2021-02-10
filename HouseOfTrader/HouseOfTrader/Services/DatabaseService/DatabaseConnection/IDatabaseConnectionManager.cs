using SQLite;
namespace HouseOfTrader.Services.DatabaseService.DatabaseConnection
{
    public interface IDatabaseConnectionManager
    {
        /// <summary>
        /// Gets the SQLite connection object.
        /// </summary>
        /// <returns>The SQLiteConnection</returns>
        SQLiteConnection GetConnection();
    }
}
