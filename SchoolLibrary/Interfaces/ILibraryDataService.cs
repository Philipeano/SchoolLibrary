using SchoolLibrary.Models;

namespace SchoolLibrary.Interfaces
{
    public interface ILibraryDataService
    {
        // Create a new record
        public void CreateBook(string title, string author, int yearPublished, string category);

        // Fetch all records
        public IEnumerable<Book> FetchAllBooks();

        // Fetch a specific record
        public Book FetchBookByTitle(string title);

        // Update a specific record
        public void UpdateBook(long serialNumber, string title, string author, int yearPublished, string category);

        // Delete a specific record
        public void DeleteBook(long serialNumber);
    }
}
