namespace IMDb_Movie_Management_System.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using IMDb_Movie_Management_System.Auth;
    using IMDb_Movie_Management_System.Models.DB;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;


    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthRepository _repo;

        public AuthController()
        {
            _repo = new AuthRepository();
        }

        // SIGNUP
        [HttpPost("signup")]
        public IActionResult Signup(User user)
        {
            if (string.IsNullOrEmpty(user.MailId) || string.IsNullOrEmpty(user.Password))
                return BadRequest("Email and Password required");

            _repo.Add(user);

            return Ok("User registered successfully");
        }

        // LOGIN
        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var existingUser = _repo.Get(user.MailId, user.Password);

            if (existingUser == null)
                return Unauthorized("Invalid credentials");

            var token = GenerateToken(user.MailId);

            return Ok(new { token });
        }

        private string GenerateToken(string email)
        {
            var key = new SymmetricSecurityKey(
    Encoding.UTF8.GetBytes("THIS_IS_MY_SUPER_SECRET_KEY_123456789"));

            var credentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, email)
        };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
