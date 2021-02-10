using System.Collections.Generic;
using System.Linq;
using static HouseOfTrader.Utilities.EnumHelper;

namespace HouseOfTrader.Services.DatabaseService
{
    public interface IDatabaseServiceManager
    {
        /// <summary>
        /// Check If Table exist or not
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        bool TableExists(string tableName);

        /// <summary>
        /// Creates the table dynamically.
        /// </summary>
        /// <typeparam name="T">Class type parameter</typeparam>
        //void CreateTable<T>();
        void CreateTable(VersionCheck versionCheck);

        /// <summary>
        /// Drops the table.
        /// </summary>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        void DropTable<T>();

        /// <summary>
        /// Insert data into respective table.
        /// </summary>
        /// <param name="InsertData">Insert data object</param>
        void Insert(object InsertData);

        /// <summary>
        /// Inserts all data into respective database.
        /// </summary>
        /// <param name="InsertDatalist">List of insert data object.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        void InsertAll<T>(List<T> InsertDatalist);

        /// <summary>
        /// Excute the Select SQLite query base on the where condition provided.
        /// </summary>
        /// <returns>The data.</returns>
        /// <param name="whereFieldNames">Where field names.</param>
        /// <param name="whereFieldValues">Where field values.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        List<T> SelectData<T>(string[] whereFieldNames, string[] whereFieldValues) where T : class, new();

        /// <summary>
        /// Gets the table data.
        /// </summary>
        /// <returns>The table data.</returns>
        /// <typeparam name="T">Class type parameter.</typeparam>
        IQueryable<T> GetTableData<T>();

        /// <summary>
        /// Deletes all data of the respective table.
        /// </summary>
        /// <typeparam name="T">Class type parameter.</typeparam>
        void DeleteAll<T>();

        /// <summary>
        /// Deletes specific data from the respective table base on the where condition.
        /// </summary>
        /// <param name="whereFieldNames">Field names.</param>
        /// <param name="whereFieldValues">Field values.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        void DeleteByField<T>(string[] whereFieldNames, string[] whereFieldValues);

        /// <summary>
        /// Delete specific item.
        /// </summary>
        /// <param name="DeleteDataItem">Delete data item.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        void DeleteItem<T>(T DeleteDataItem);

        /// <summary>
        /// Deletes the multiple item.
        /// </summary>
        /// <param name="multipleDeleteItems">Multiple delete item.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        void DeleteMultipleItem<T>(List<T> multipleDeleteItems);

        /// <summary>
        /// Update specific item.
        /// </summary>
        /// <param name="UpdateItem">Update item.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        void UpdateItem<T>(T UpdateItem);

        /// <summary>
        /// Updates the multiple item.
        /// </summary>
        /// <param name="updateMultipleItems">Update multiple item.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        void UpdateMultipleItem<T>(List<T> updateMultipleItems);

        /// <summary>
        /// Updates specific data from the respective table base on the where condition.
        /// </summary>
        /// <param name="updateFieldNames">Update field names.</param>
        /// <param name="updateFieldValues">Update field values.</param>
        /// <param name="whereFieldNames">Where field names.</param>
        /// <param name="whereFieldValues">Where field values.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        void UpdateData<T>(string[] updateFieldNames, string[] updateFieldValues, string[] whereFieldNames, string[] whereFieldValues) where T : class, new();
    }
}
