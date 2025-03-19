using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using HealthFitnessTrackerAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace HealthFitnessTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public AuthController(UserManager<User> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUser request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new User // Ensure this is your 'User' model
            {
                UserName = request.Email,
                Email = request.Email,
                Name = request.Name  // Assigning Name property
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { message = "User registered successfully!" });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser request)
        {
            var users = _userManager.Users.Where(u => u.Email == request.Email).ToList();

            if (users.Count == 0)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }
            else if (users.Count > 1)
            {
                return StatusCode(500, new { message = "Multiple accounts found for this email. Please contact support." });
            }

            var user = users.First();


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["JWT:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
      
    }
}
