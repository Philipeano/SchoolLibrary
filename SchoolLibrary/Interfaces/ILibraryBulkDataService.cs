using System.Data;

namespace SchoolLibrary.Interfaces
{
    public interface ILibraryBulkDataService
    {
        public DataSet LoadData();

        public bool PersistData(DataSet dataSet);
    }
}
