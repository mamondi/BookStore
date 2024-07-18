using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DataAccess;
using Models;

namespace Operations
{
    public class BookOperations
    {
        private readonly DBContext dbContext;

        public BookOperations()
        {
            dbContext = new DBContext();
        }

        public void AddBook(BookModel book)
        {
            using (IDbConnection connection = dbContext.Connection)
            {
                connection.Open();
                string insertBookQuery = @"
                    INSERT INTO Books (BookTitle, BookAuthor, BookPublisher, BookPages, BookGenre, PublicationYear, CostPrice, SellingPrice, IsContinuation)
                    VALUES (@Title, @Author, @Publisher, @Pages, @Genre, @PublicationYear, @Cost, @Price, @IsContinuation)";
                connection.Execute(insertBookQuery, book);
            }
        }

        public void DeleteBook(int bookID)
        {
            using (IDbConnection connection = dbContext.Connection)
            {
                connection.Open();
                string deleteBookQuery = "DELETE FROM Books WHERE BookID = @BookID";
                connection.Execute(deleteBookQuery, new { BookID = bookID });
            }
        }

        public void RedactBook(BookModel book)
        {
            using (IDbConnection connection = dbContext.Connection)
            {
                connection.Open();
                string redactBookQuery = @"
                    UPDATE Books
                    SET BookTitle = @Title, BookAuthor = @Author, BookPublisher = @Publisher, BookPages = @Pages, BookGenre = @Genre, PublicationYear = @PublicationYear, CostPrice = @Cost, SellingPrice = @Price, IsContinuation = @IsContinuation
                    WHERE BookID = @BookID";
                connection.Execute(redactBookQuery, book);
            }
        }

        public List<BookModel> GetBooks()
        {
            using (IDbConnection connection = dbContext.Connection)
            {
                connection.Open();
                string getBooksQuery = "SELECT * FROM Books";
                return connection.Query<BookModel>(getBooksQuery).ToList();
            }
        }

    }
}
