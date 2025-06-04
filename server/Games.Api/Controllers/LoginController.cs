using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static System.Net.WebRequestMethods;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Games.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // POST: api/<LoginController>
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest.Name == "aaa" && loginRequest.Password == "123")
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "aaa"),
                new Claim(ClaimTypes.Role, "manager")
            };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SomeLongKeyToGenerateMyJwtTokenAAAAAAAAAAAAAAAAAA"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7211",
                    audience: "https://localhost:7211",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();

        }


    }
}
