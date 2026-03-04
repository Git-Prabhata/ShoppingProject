using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIGateway.Controllers
{
	[ApiController]
	[Route("api/auth")]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _config;

		public AuthController(IConfiguration config)
		{
			_config = config;
		}

		[HttpPost("login")]
		public IActionResult Login()
		{
			return Ok("Auth Working");
		}
		//[HttpPost("login")]
		//public IActionResult Login()
		//{
		//	var claims = new[]
		//	{
		//	new Claim(ClaimTypes.Name, "Admin")
		//};

		//	var key = new SymmetricSecurityKey(
		//		Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));

		//	var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		//	var token = new JwtSecurityToken(
		//		issuer: _config["JwtSettings:Issuer"],
		//		audience: _config["JwtSettings:Audience"],
		//		claims: claims,
		//		expires: DateTime.Now.AddMinutes(30),
		//		signingCredentials: creds);

		//	return Ok(new
		//	{
		//		token = new JwtSecurityTokenHandler().WriteToken(token)
		//	});
		//}

	}
}
