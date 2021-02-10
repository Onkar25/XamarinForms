using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HouseOfTrader.Models;
using HouseOfTrader.Services.DatabaseService.DatabaseConnection;
using SQLite;
using static HouseOfTrader.Utilities.EnumHelper;

namespace HouseOfTrader.Services.DatabaseService
{
    public class DatabaseServiceManager : IDatabaseServiceManager
    {
        #region Data Members
        public IDatabaseConnectionManager DatabaseConnectionManager { get; set; }

        public SQLiteConnection Connection { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the DatabaseServiceManager class.
        /// </summary>
        /// <param name="databaseConnectionManager">Database connection manager.</param>
        public DatabaseServiceManager(IDatabaseConnectionManager databaseConnectionManager)
        {
            DatabaseConnectionManager = databaseConnectionManager;
            Connection = DatabaseConnectionManager.GetConnection();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the table dynamically.
        /// </summary>
        /// <typeparam name="T">Class type parameter</typeparam>
        //public void CreateTable<T>()
        public void CreateTable(VersionCheck versionCheck)
        {
            try
            {

                switch (versionCheck)
                {
                    case VersionCheck.First:
                        Connection.CreateTable<FutureBhavCopy>();
                        Connection.CreateTable<CashBhavCopy>();
                        Connection.CreateTable<CMVolt>();
                        Connection.CreateTable<CFInsiderTrading>();
                        Connection.CreateTable<Bulk>();
                        Connection.CreateTable<CFPledgeData>();
                        Connection.CreateTable<MWPreOpenMarket>();
                        Connection.CreateTable<BseSlb>();
                        break;
                    case VersionCheck.Same:
                    case VersionCheck.Updated:
                        TableAleration();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DatabaseServiceManager::CreateTable : " + ex.Message);
            }
        }

        void TableAleration()
        {
            AlterTableQuery<FutureBhavCopy>();
            AlterTableQuery<CashBhavCopy>();
            AlterTableQuery<CMVolt>();
            AlterTableQuery<CFInsiderTrading>();
            AlterTableQuery<Bulk>();
            AlterTableQuery<CFPledgeData>();
            AlterTableQuery<MWPreOpenMarket>();
            AlterTableQuery<BseSlb>();
        }
        public void AlterTableQuery<T>()
        {
            try
            {
                var tableInfo = (T)Activator.CreateInstance(typeof(T));
                string tableName = tableInfo.GetType().Name;
                if (TableExists(tableName))
                {
                    var tableData = GetTableData<T>().ToList();
                    Connection.Execute("ALTER TABLE " + tableName + " RENAME TO MIGRATED" + tableName);
                    Connection.CreateTable(tableInfo.GetType());
                    InsertAll<T>(tableData);
                    Connection.Execute("DROP TABLE IF EXISTS MIGRATED" + tableName);
                }
                else
                {
                    Connection.CreateTable(tableInfo.GetType());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DatabaseServiceManager::AlterTableQuery : " + ex.Message);
            }
        }
        /// <summary>
        /// Drops the table.
        /// </summary>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public void DropTable<T>()
        {
            try
            {
                var tableInfo = (T)Activator.CreateInstance(typeof(T));
                if (TableExists(tableInfo.GetType().Name))
                {
                    Connection.DropTable<T>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DatabaseServiceManager::DropTable : " + ex.Message);
            }
        }

        /// <summary>
        /// Check whether table exists or not.
        /// </summary>
        /// <returns><c>true</c>, if exists was tabled, <c>false</c> otherwise.</returns>
        /// <param name="tableName">Table name.</param>
        public bool TableExists(String tableName)
        {
            var tableExist = Connection.GetTableInfo(tableName);
            return tableExist.Any();
        }

        /// <summary>
        /// Insert data into respective table.
        /// </summary>
        /// <param name="InsertData">Insert data object</param>
        public void Insert(object InsertData)
        {
            try
            {
                if (InsertData != null)
                {
                    Connection.Insert(InsertData);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("DatabaseServiceManager::Insert : " + ex.Message);
            }
        }

        /// <summary>
        /// Inserts all data into respective database.
        /// </summary>
        /// <param name="InsertDatalist">List of insert data object.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        public void InsertAll<T>(List<T> InsertDatalist)
        {
            try
            {
                if (InsertDatalist != null && InsertDatalist.Count > 0)
                {
                    Connection.InsertAll(InsertDatalist);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DatabaseServiceManager::InsertAll : " + ex.Message);
            }
        }

        /// <summary>
        /// Excute the Select SQLite query base on the where condition provided.
        /// </summary>
        /// <returns>The data.</returns>
        /// <param name="whereFieldNames">Where field names.</param>
        /// <param name="whereFieldValues">Where field values.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        public List<T> SelectData<T>(string[] whereFieldNames, string[] whereFieldValues) where T : class, new()
        {
            var type = typeof(T);
            List<T> results = new List<T>();
            string selectQuery = string.Empty;
            StringBuilder whereClause = new StringBuilder();

            if (type != null)
            {
                try
                {
                    if (whereFieldNames != null && whereFieldNames.Any())
                    {
                        for (int i = 0; i < whereFieldNames.Length; i++)
                        {
                            if (i == (whereFieldNames.Length - 1))
                            {
                                whereClause.Append($"{whereFieldNames[i]}='{whereFieldValues[i]}'");
                            }
                            else
                            {
                                whereClause.Append($"{whereFieldNames[i]}='{whereFieldValues[i]}' and ");
                            }
                        }
                    }
                    selectQuery = $"select * from {typeof(T).Name} where {whereClause}";

                    var result = Connection.Query<T>(selectQuery.ToString());
                    if (result != null || result.Count != 0)
                    {
                        foreach (var r in result)
                        {
                            if (r != null)
                            {
                                results.Add(r);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("DatabaseServiceManager::SelectData : " + ex.Message);
                }
            }
            return results != null && results.Count > 0 ? results : new List<T>();
        }

        /// <summary>
        /// Gets the table data.
        /// </summary>
        /// <returns>The table data.</returns>
        /// <typeparam name="T">Class type parameter.</typeparam>
        public IQueryable<T> GetTableData<T>()
        {
            try
            {
                var tableDataQuery = new TableQuery<T>(Connection);
                return tableDataQuery.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception("DatabaseServiceManager::GetTableData : " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes all data of the respective table.
        /// </summary>
        /// <typeparam name="T">Class type parameter.</typeparam>
        public void DeleteAll<T>()
        {
            try
            {
                Connection.DeleteAll<T>();
            }
            catch (Exception ex)
            {
                throw new Exception("DatabaseServiceManager::DeleteAll : " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes specific data from the respective table base on the where condition.
        /// </summary>
        /// <param name="whereFieldNames">Field names.</param>
        /// <param name="whereFieldValues">Field values.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        public void DeleteByField<T>(string[] whereFieldNames, string[] whereFieldValues)
        {
            StringBuilder multipleDeleteQuery = new StringBuilder();
            try
            {
                if (whereFieldNames.Any() && whereFieldValues.Any())
                {
                    multipleDeleteQuery.Append($"delete from {typeof(T).Name} where");

                    for (int i = 0; i < whereFieldNames.Length; i++)
                    {
                        if (i == (whereFieldNames.Length - 1))
                        {
                            multipleDeleteQuery.Append($" {whereFieldNames[i]} = '{whereFieldValues[i]}'");
                        }
                        else
                        {
                            multipleDeleteQuery.Append($" {whereFieldNames[i]} = '{whereFieldValues[i]}' and");
                        }
                    }
                    int result = Connection.Execute(multipleDeleteQuery.ToString());

                }
            }
            catch (Exception ex)
            {
                throw new Exception("DatabaseServiceManager::DeleteByField : " + ex.Message);
            }
        }

        /// <summary>
        /// Delete specific item.
        /// </summary>
        /// <param name="DeleteDataItem">Delete data item.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        public void DeleteItem<T>(T DeleteDataItem)
        {
            try
            {
                Connection.Delete(DeleteDataItem);
            }
            catch (Exception ex)
            {
                throw new Exception("DatabaseServiceManager::DeleteItem : " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes the multiple item.
        /// </summary>
        /// <param name="multipleDeleteItems">Multiple delete item.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        public void DeleteMultipleItem<T>(List<T> multipleDeleteItems)
        {
            try
            {
                foreach (var deleteItem in multipleDeleteItems)
                {
                    Connection.Delete(deleteItem);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DatabaseServiceManager::DeleteMultipleItem : " + ex.Message);
            }
        }

        /// <summary>
        /// Update specific item.
        /// </summary>
        /// <param name="UpdateItem">Update item.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        public void UpdateItem<T>(T UpdateItem)
        {
            try
            {
                Connection.Update(UpdateItem);
            }
            catch (Exception ex)
            {
                throw new Exception("DatabaseServiceManager::UpdateItem : " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the multiple item.
        /// </summary>
        /// <param name="updateMultipleItems">Update multiple item.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        public void UpdateMultipleItem<T>(List<T> updateMultipleItems)
        {
            try
            {
                Connection.UpdateAll(updateMultipleItems);
            }
            catch (Exception ex)
            {
                throw new Exception("DatabaseServiceManager::UpdateMultipleItem : " + ex.Message);
            }
        }

        /// <summary>
        /// Updates specific data from the respective table base on the where condition.
        /// </summary>
        /// <param name="updateFieldNames">Update field names.</param>
        /// <param name="updateFieldValues">Update field values.</param>
        /// <param name="whereFieldNames">Where field names.</param>
        /// <param name="whereFieldValues">Where field values.</param>
        /// <typeparam name="T">Class type parameter.</typeparam>
        public void UpdateData<T>(string[] updateFieldNames, string[] updateFieldValues, string[] whereFieldNames, string[] whereFieldValues) where T : class, new()
        {
            StringBuilder updateFields = new StringBuilder();
            StringBuilder whereClause = new StringBuilder();
            try
            {
                if (whereFieldNames != null && whereFieldNames.Any())
                {
                    for (int i = 0; i < whereFieldNames.Length; i++)
                    {
                        if (i == (whereFieldNames.Length - 1))
                        {
                            whereClause.Append($"{whereFieldNames[i]}='{whereFieldValues[i]}'");
                        }
                        else
                        {
                            whereClause.Append($"{whereFieldNames[i]}='{whereFieldValues[i]}' and ");
                        }
                    }
                }

                if (updateFieldNames != null && updateFieldNames.Any())
                {
                    for (int i = 0; i < updateFieldNames.Length; i++)
                    {
                        if (i == (updateFieldNames.Length - 1))
                        {
                            updateFields.Append($"{updateFieldNames[i]}='{updateFieldValues[i].Replace("'", "''")}'");
                        }
                        else
                        {
                            updateFields.Append($"{updateFieldNames[i]}='{updateFieldValues[i].Replace("'", "''")}', ");
                        }
                    }
                }
                string updateQuery = $"update {typeof(T).Name} set {updateFields} where {whereClause}";
                var result = Connection.Execute(updateQuery);
            }
            catch (Exception ex)
            {
                throw new Exception("DatabaseServiceManager::UpdateData : " + ex.Message);
            }
        }
        #endregion

    }
}
