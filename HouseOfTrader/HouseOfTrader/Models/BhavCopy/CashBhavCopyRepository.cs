using System.Collections.Generic;
using System.Linq;
using HouseOfTrader.Services.DatabaseService.BaseDatabaseModule;
namespace HouseOfTrader.Models.BhavCopy
{
    public class CashBhavCopyRepository : BaseDatabaseModule
    {
        static CashBhavCopyRepository instance;
        private CashBhavCopyRepository()
        {
        }
        public static CashBhavCopyRepository Instance
        {
            get
            {
                return instance ?? new CashBhavCopyRepository();
            }
        }
        public List<CashBhavCopy> GetFilterRecords()
        {
            return DatabaseServiceManager.GetTableData<CashBhavCopy>().ToList();
        }
        public void AddOrRemoveFilteredRecord(CashBhavCopy filteredRecord)
        {
            var AllFilter = GetFilterRecords();
            CashBhavCopy filteredRecordExist = AllFilter.FirstOrDefault((obj) => obj.ID == filteredRecord.ID);
            if (filteredRecordExist != null)
            {
                RemoveFilteredRecord(filteredRecordExist);
            }
            else
            {
                if (filteredRecord != null)
                {
                    AddFilteredRecord(filteredRecord);
                }
            }
        }
        public CashBhavCopy CheckIfExist(CashBhavCopy filteredRecord)
        {
            return GetFilterRecords().FirstOrDefault((obj) => obj.ID == filteredRecord.ID);
        }
        void AddFilteredRecord(CashBhavCopy filteredRecord)
        {
            if (filteredRecord != null)
            {
                DatabaseServiceManager.Insert(filteredRecord);
            }
        }
        public void AddMultipleRecord(List<CashBhavCopy> filteredRecords)
        {
            if (filteredRecords != null && filteredRecords.Count>0)
            {
                DatabaseServiceManager.InsertAll(filteredRecords);
            }
        }
        public void RemoveFilteredRecord(CashBhavCopy filteredRecord)
        {
            if (filteredRecord != null)
            {
                DatabaseServiceManager.DeleteItem<CashBhavCopy>(filteredRecord);
            }
        }
        public void RemoveAllFilteredRecord()
        {
            DatabaseServiceManager.DeleteAll<CashBhavCopy>();
        }
    }
}