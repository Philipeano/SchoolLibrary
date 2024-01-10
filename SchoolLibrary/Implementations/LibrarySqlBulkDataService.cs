using Microsoft.Data.SqlClient;
using SchoolLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.Implementations
{
    public class LibrarySqlBulkDataService : ILibraryBulkDataService
    {
        private const string _connectionString = "server=localhost; integrated security=True;initial catalog=SchoolLibraryDB; TrustServerCertificate=True";
        private SqlCommand _selectCommand;
        private DataSet _libaryDataset;
        private SqlDataAdapter _adapter;

        public LibrarySqlBulkDataService()
        {
            _selectCommand = new SqlCommand("SELECT * FROM Books ORDER BY SerialNumber");
            _libaryDataset = new DataSet();
        }

        public DataSet LoadData()
        {
            Console.WriteLine("Establishing a connection to the database...");
            using (_adapter = new SqlDataAdapter(_selectCommand.CommandText, _connectionString))
            {
                Console.WriteLine("Connection established. Filling dataset with library data...");
                _adapter.Fill(_libaryDataset);
                Console.WriteLine("Successfully populated the dataset with library data...");
            }
            return _libaryDataset;
        }


        public bool PersistData(DataSet dataSet)
        {
            try
            {
                Console.WriteLine("Establishing a connection to the database...");
                using (_adapter = new SqlDataAdapter(_selectCommand.CommandText, _connectionString))
                {
                    Console.WriteLine("Connection established...");

                    // Use SQLCommandBuilder to generate remaining commands for the adapter
                    Console.WriteLine("Generating missing SQL commands...");
                    SqlCommandBuilder builder = new SqlCommandBuilder(_adapter);

                    Console.WriteLine("Generated the following commands:");
                    Console.WriteLine(builder.GetUpdateCommand().CommandText);
                    Console.WriteLine(builder.GetInsertCommand().CommandText);
                    Console.WriteLine(builder.GetDeleteCommand().CommandText);

                    Console.WriteLine("Attempting to write changes to the database...");
                    _adapter.Update(dataSet);
                    Console.WriteLine("Successfully persisted changes to the database...");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Operation failed: {ex.Message}");
                return false;
            }

        }
    }
}
