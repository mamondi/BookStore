using DataAccess;
using Models;
using System.Data;
using Dapper;

namespace Operations
{
    public class UserOperations    
    {
        private DBContext dbContext;

        public UserOperations(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddUser(UserModel user)
        {
            using (IDbConnection connection = dbContext.Connection)
            {
                connection.Open();
                string insertUserQuery = @"
                    INSERT INTO Users (Username, Password)
                    VALUES (@Username, @Password)";
                connection.Execute(insertUserQuery, user);
            }
        }

        public void LogInUser(UserModel user)
        {
            using (IDbConnection connection = dbContext.Connection)
            {
                connection.Open();
                string loginUserQuery = @"
                    SELECT * FROM Users
                    WHERE Username = @Username AND Password = @Password";
                var result = connection.Query<UserModel>(loginUserQuery, new { Username = user.Username, Password = user.Password });

            }
        }


    }
}
