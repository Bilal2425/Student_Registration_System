using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Student_Registration_System.Models;

namespace Student_Registration_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly string? _connectionString;

        public LoginController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServerConnection");
        }

  

        [HttpPost]
        public IActionResult LoginUser([FromBody] User model)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM users WHERE username = @UserName AND password = @Password";

                    var user = connection.QueryFirstOrDefault<User>(query, new { model.UserName, model.Password });

                    if (user != null)
                    {
                        // Authentication successful
                        // You may perform additional actions here if needed
                        return Ok("Login successful");
                    }
                    else
                    {
                        return Unauthorized("Invalid username or password");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
