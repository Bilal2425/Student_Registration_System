using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Registration_System.Models;
using System.Data;
using System.Data.SqlClient;

namespace Student_Registration_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly string? _connectionString;
        

        public RegistrationController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServerConnection");
        }

        [HttpPost("RegisterStudent")]
        public IActionResult RegisterStudent([FromForm] Registration model)
        {
            try
            {

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    if (connection.State == ConnectionState.Open)
                    {
                        Console.WriteLine("Database connection successful!");
                    }
                    else
                    {
                        Console.WriteLine("Database connection failed!");
                    }

                    string query = "INSERT INTO users (username, password) VALUES (@UserName, @Password)";

                    connection.Execute(query, new { model.UserName, model.Password });

                    return Ok("Student registered successfully");
                    //return RedirectToAction("Index");
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
