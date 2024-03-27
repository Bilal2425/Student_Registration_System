using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Student_Registration_System.Business;
using Student_Registration_System.Models;
using System;

namespace Student_Registration_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly RegistrationManager _registrationManager;

        public RegistrationController(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("SqlServerConnection");
            var registrationRepository = new Repository.RegistrationRepository(connectionString);
            _registrationManager = new RegistrationManager(registrationRepository);
        }

        [HttpPost("RegisterStudent")]
        public IActionResult RegisterStudent([FromForm] Registration model)
        {
            try
            {
                _registrationManager.RegisterStudent(model.UserName, model.Password);
                return Ok("Student registered successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
