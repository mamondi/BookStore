using Dapper;
using System.Data.SQLite;
using System.Data;
using System.Data.Common;

namespace DataAccess
{
    public class DBContext
    {
        private const string connectionString = "Data Source=Bookstore.db;Version=3;";

        public IDbConnection Connection = new SQLiteConnection(connectionString);

        public void EnsureDatabaseSetup()
        {
            using (var connection = Connection)
            {
                connection.Open();
                string createBooksTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Books (
                        BookID INTEGER PRIMARY KEY AUTOINCREMENT,
                        BookTitle TEXT NOT NULL,
                        BookAuthor TEXT NOT NULL,
                        BookPublisher TEXT NOT NULL,
                        BookPages INTEGER NOT NULL,
                        BookGenre TEXT NOT NULL,
                        PublicationYear INTEGER NOT NULL,
                        CostPrice REAL NOT NULL,
                        SellingPrice REAL NOT NULL,
                        IsContinuation INTEGER NOT NULL
                    )";
                string createUsersTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        Password TEXT NOT NULL
                    )";
                connection.Execute(createBooksTableQuery);
                connection.Execute(createUsersTableQuery);
            }
        }
    }
}
