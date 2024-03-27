using Dapper;
using Student_Registration_System.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Student_Registration_System.Repository
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServerConnection");
        }

        public User GetUser(string userName, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM users WHERE username = @UserName AND password = @Password";

                return connection.QueryFirstOrDefault<User>(query, new { UserName = userName, Password = password });
            }
        }
    }
}
