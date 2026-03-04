using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace JWTWEBAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _config;

		public AuthController(IConfiguration config)
		{
			_config = config;
		}

		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginRequest Request)
		{
			// Dummy check
			if (Request.Username == "admin" && Request.Password == "1234")
			{
				var token = GenerateToken(Request.Username);
				return Ok(new { token });
			}

			return Unauthorized();
		}
		[Authorize]
		[HttpGet("secure")]
		public IActionResult SecureData()
		{
			return Ok("This is protected data");
		}
		[HttpGet("Notsecure")]
		public IActionResult NotSecureData()
		{
			return Ok("This isNot a protected data");
		}
		private string GenerateToken(string username)
		{
			var claims = new[]
			{
			new Claim(ClaimTypes.Name, username),
			new Claim(ClaimTypes.Role, "Admin")
		};

			var key = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(_config["Jwt:Key"])
			);

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _config["Jwt:Issuer"],
				audience: _config["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
