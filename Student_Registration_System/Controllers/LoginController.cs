using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Student_Registration_System.Business;
using Student_Registration_System.Models;
using System;

namespace Student_Registration_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager _userManager;

        public LoginController(IConfiguration configuration)
        {
            _userManager = new UserManager(configuration);
        }

        [HttpPost]
        public IActionResult LoginUser([FromBody] User model)
        {
            try
            {
                var user = _userManager.GetUser(model.UserName, model.Password);

                if (user != null)
                {
                    return Ok("Login successful");
                }
                else
                {
                    return Unauthorized("Invalid username or password");
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
