
// Create an instance of the LibraryBulkDataService and test its functionality

using SchoolLibrary.Implementations;
using SchoolLibrary.Interfaces;
using System.Data;

ILibraryBulkDataService libraryBulkDataService = new LibrarySqlBulkDataService();

Console.WriteLine();
Console.WriteLine("-----------------------------------------------------------------------------------------------");
Console.WriteLine();

// Retrieve all data from the database

var libraryData = libraryBulkDataService.LoadData();


// Display books data as returned by the service

Console.WriteLine("Serial Number \t\t Title \t\t Author \t\t Category \t\t Year Published");
Console.WriteLine("-----------------------------------------------------------------------------------------------");

var booksDataTable = libraryData.Tables[0];
//var booksDataTable = libraryData.Tables["Books"];

foreach (DataRow row in booksDataTable.Rows)
{
    // Console.WriteLine($"{row[0]} \t\t {row[1]} \t\t {row[2]} \t\t {row[3]} \t\t {row[4]}");
    Console.WriteLine($"{row["SerialNumber"]} \t\t {row["Title"]} \t\t {row["Author"]} \t\t {row["Category"]} \t\t {row["YearPublished"]}");
}
Console.WriteLine("-----------------------------------------------------------------------------------------------");
Console.WriteLine();


// Make a small edit to a spefic row in the data table
libraryData.Tables[0].Rows[0]["Category"] = "Novel";

// Add a few new rows to the data table
libraryData.Tables[0].Rows.Add(new object[] { DBNull.Value, "The Hunter", "Kachi", "2001", "Novel" });
libraryData.Tables[0].Rows.Add(new object[] { DBNull.Value, "Politicians", "Rufai", "2010", "Novel" });
libraryData.Tables[0].Rows.Add(new object[] { DBNull.Value, "My Watch", "Olusegun Obasanjo", "2013", "Biography" });

// Delete a row from the data table
libraryData.Tables[0].Rows[4].Delete();


var savedSuccessfully = libraryBulkDataService.PersistData(libraryData);



