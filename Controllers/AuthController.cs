using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductManagementAPI.Models;
using ProductManagementAPI.Helpers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hangfire.Common;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagementAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private static List<User> _users = new List<User> // Mock User Database
        {
            new User { Username = "admin", Password = "password" },
            new User { Username = "user1", Password = "password123" }
        };

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginUser)
        {
            var user = _users.FirstOrDefault(u => u.Username == loginUser.Username && u.Password == loginUser.Password);
            if (user == null)
                return Unauthorized(new { message = "Invalid username or password" });

            var token = JwtHelper.GenerateJwtToken(user.Username, _config);
            return Ok(new { token });
        }

        [HttpPut("update/{username}")]
        [Authorize]
        public IActionResult UpdateUser(string username, [FromBody] User updatedUser)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user == null)
                return NotFound(new { message = "User not found" });

            user.Password = updatedUser.Password; // Update password
            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("delete/{username}")]
        [Authorize]
        public IActionResult DeleteUser(string username)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user == null)
                return NotFound(new { message = "User not found" });

            _users.Remove(user);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
