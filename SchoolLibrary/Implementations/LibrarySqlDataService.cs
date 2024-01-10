using SchoolLibrary.Interfaces;
using SchoolLibrary.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.Implementations
{
    public class LibrarySqlDataService : ILibraryDataService
    {

        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public LibrarySqlDataService()
        {
            _connection = new SqlConnection("server=localhost; integrated security=True;initial catalog=SchoolLibraryDB; TrustServerCertificate=True");
        }

        public void CreateBook(string title, string author, int yearPublished, string category)
        {
            // Define an SQL command for INSERT, making use of SQL parameters for the field values
            _command = new SqlCommand("INSERT INTO Books (Title, Author, YearPublished, Category) VALUES (@title, @author, @year, @category)", _connection);
            _command.Parameters.AddWithValue("title", title);
            _command.Parameters.AddWithValue("author", author);
            _command.Parameters.AddWithValue("year", yearPublished);
            _command.Parameters.AddWithValue("category", category);

            // Open the connection, if it's not already open
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            // Execute the command using the open connection
            _command.ExecuteNonQuery();

            // Close the connection
            _connection.Close();
        }

        public void DeleteBook(long serialNumber)
        {
            // Define an SQL command for DELETE, making use of an SQL parameter for the unique identifier
            _command = new SqlCommand("DELETE FROM Books WHERE SerialNumber = @serialNumber", _connection);
            _command.Parameters.AddWithValue("serialNumber", serialNumber);

            // Open the connection, if it's not already open
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            // Execute the command using the open connection
            _command.ExecuteNonQuery();

            // Close the connection
            _connection.Close();
        }

        public IEnumerable<Book> FetchAllBooks()
        {
            var books = new List<Book>();

            // Define an SQL command for SELECT, to retrieve all items            
            _command = new SqlCommand("SELECT * FROM Books", _connection);

            // Open the connection, if it's not already open
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            // Execute the command as a query, and assign it to a data reader
            _reader = _command.ExecuteReader();

            // Read the results iteratively from the data reader into an in-memory collection
            if (!_reader.HasRows) 
            {
                return books;
            }

            while (_reader.Read())
            {
                books.Add(new Book
                {
                    SerialNumber = _reader.GetInt64("SerialNumber"),
                    Title = _reader.GetString("title"),
                    Author  = _reader.GetString("Author"),
                    YearPublished   = _reader.GetInt32("YearPublished"),
                    Category = _reader.GetString("Category")
                });
            }

            // Display the contents of the collection
            return books;
        }

        public Book FetchBookByTitle(string title)
        {
            Book book = null;

            // Define an SQL command for SELECT, to retrieve the matching book            
            _command = new SqlCommand("SELECT * FROM Books WHERE Title LIKE @title", _connection);
            _command.Parameters.AddWithValue("title", "%" + title + "%");

            // Open the connection, if it's not already open
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            // Execute the command as a query, and assign it to a data reader
            _reader = _command.ExecuteReader();

            // Read the results iteratively from the data reader to retrieve the book
            if (!_reader.HasRows)
            {
                return book;
            }

            while (_reader.Read())
            {
                book = new Book
                {
                    SerialNumber = _reader.GetInt64("SerialNumber"),
                    Title = _reader.GetString("title"),
                    Author = _reader.GetString("Author"),
                    YearPublished = _reader.GetInt32("YearPublished"),
                    Category = _reader.GetString("Category")
                };
            }

            // Display the book that was found
            return book;
        }

        public void UpdateBook(long serialNumber, string title, string author, int yearPublished, string category)
        {
            // Define an SQL command for UPDATE, making use of SQL parameters for the field values and the unique identifier
            _command = new SqlCommand("UPDATE Books SET Title = @title, Author = @author, YearPublished = @year, Category = @category WHERE SerialNumber = @serialNumber", _connection);
            _command.Parameters.AddWithValue("title", title);
            _command.Parameters.AddWithValue("author", author);
            _command.Parameters.AddWithValue("year", yearPublished);
            _command.Parameters.AddWithValue("category", category);
            _command.Parameters.AddWithValue("serialNumber", serialNumber);

            // Open the connection, if it's not already open
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            // Execute the command using the open connection
            _command.ExecuteNonQuery();

            // Close the connection
            _connection.Close();
        }
    }
}
