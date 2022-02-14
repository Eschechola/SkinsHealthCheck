using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SkinsApiHealthChecks.Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("/auth/login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] string password)
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                    return StatusCode(400, "Password can not be null or empty!");

                if (password != _configuration["Jwt:Password"])
                    return StatusCode(401, "Password is invalid!");

                return Ok(CreateToken());
            }
            catch (Exception)
            {
                return StatusCode(500, "An internal server error has been occurred");
            }
        }

        private string CreateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
