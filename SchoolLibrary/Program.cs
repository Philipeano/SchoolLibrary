
// Create an instance of the LibraryDataService and test its functionality

using SchoolLibrary.Implementations;
using SchoolLibrary.Interfaces;

ILibraryDataService libraryDataService = new LibrarySqlDataService();


// Present a menu to the user to select an operation to perform
Console.WriteLine();
Console.WriteLine("-----------------------------------------------------------------------------------------------");
Console.WriteLine();
Console.WriteLine("Welcome to School Library App! \n\n What would you like to do?");
Console.WriteLine("1.\tView all books");
Console.WriteLine("2.\tFind a book by title");
Console.WriteLine("3.\tAdd a new book");
Console.WriteLine("4.\tUpdate a book");
Console.WriteLine("5.\tDelete a book");
Console.WriteLine();

var userSelection = int.Parse(Console.ReadLine()); // TODO: Validate the input to ensure it's an integer value

switch (userSelection)
{
	case 1:
        // Retrieve all books in the library
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine();
        
        var bookList = libraryDataService.FetchAllBooks();

        Console.WriteLine("Serial Number \t\t Title \t\t Author \t\t Category \t\t Year Published");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        foreach (var book in bookList)
        {
            Console.WriteLine($"{book.SerialNumber} \t\t {book.Title} \t\t {book.Author} \t\t {book.Category} \t\t {book.YearPublished}");
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine();
        break;

    case 2:
        Console.WriteLine();
        Console.WriteLine("Enter a title to search for...");
        var searchText = Console.ReadLine();
        
        var matchingBook = libraryDataService.FetchBookByTitle(searchText);

        Console.WriteLine("Serial Number \t\t Title \t\t Author \t\t Category \t\t Year Published");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine($"{matchingBook.SerialNumber} \t\t {matchingBook.Title} \t\t {matchingBook.Author} \t\t {matchingBook.Category} \t\t {matchingBook.YearPublished}");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        break;

    case 3:
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
        break;

    case 4:
        // Prompt the user for serial number, title, author, year published and category, then update the book in the library
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("What is the serial number of the book you wish to update?");
        var serialNumberToUpdate = int.Parse(Console.ReadLine()); // TODO: Add validation

        Console.WriteLine();
        Console.WriteLine("Enter a new title for the book...");
        var bookTitleToUpdate = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Enter a new author name...");
        var bookAuthorToUpdate = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Enter a new year of publication...");
        var yearPublishedToUpdate = int.Parse(Console.ReadLine()); // TODO: Validate the input to be sure it's appropriate for a year value

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Enter a new category for the book...");
        var bookCategoryToUpdate = Console.ReadLine();
        Console.WriteLine("-----------------------------------------------------------------------------------------------");

        libraryDataService.UpdateBook(serialNumberToUpdate, bookTitleToUpdate, bookAuthorToUpdate, yearPublishedToUpdate, bookCategoryToUpdate);
        Console.WriteLine();
        Console.WriteLine("Book updated successfully!");
        break;

    case 5:
        // Prompt the user the serial number, then delete the book from the library
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("What is the serial number of the book you wish to delete?");
        var serialNumberToDelete = int.Parse(Console.ReadLine()); // TODO: Add validation

        libraryDataService.DeleteBook(serialNumberToDelete);
        Console.WriteLine();
        Console.WriteLine("Book deleted successfully!");
        break;

    default:
		break;
}



