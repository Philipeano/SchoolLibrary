
// Create an instance of the LibraryDataService and test its functionality

using SchoolLibrary.Implementations;
using SchoolLibrary.Interfaces;

ILibraryDataService libraryDataService = new LibrarySqlDataService();

// Prompt the user for title, author, year published and category, then add the book to the library
Console.WriteLine();
Console.WriteLine("-----------------------------------------------------------------------------------------------");
Console.WriteLine();
Console.WriteLine("Enter a title for the book...");
var bookTitle = Console.ReadLine();

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Enter the author name...");
var bookAuthor = Console.ReadLine();

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Enter the year of publication...");
var yearPublished = int.Parse(Console.ReadLine()); // TODO: Validate the input to be sure it's appropriate for a year value

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Enter a category for the book...");
var bookCategory = Console.ReadLine();
Console.WriteLine("-----------------------------------------------------------------------------------------------");

libraryDataService.CreateBook(bookTitle, bookAuthor, yearPublished, bookCategory);
Console.WriteLine();
Console.WriteLine("Book added successfully!");

// Retrieve all books in the library
libraryDataService.FetchAllBooks();