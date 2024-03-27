using Dapper;
using Student_Registration_System.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Student_Registration_System.Repository
{
    public class RegistrationRepository
    {
        private readonly string _connectionString;

        public RegistrationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void RegisterStudent(string userName, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO users (username, password) VALUES (@UserName, @Password)";

                connection.Execute(query, new { UserName = userName, Password = password });
            }
        }
    }
}
