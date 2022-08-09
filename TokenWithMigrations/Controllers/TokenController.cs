using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenWithMigrations.Models;

namespace TokenWithMigrations.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : Controller
    {
        public IConfiguration _configuration;
        private readonly DatabaseContext _db;

        public TokenController(IConfiguration configuration,DatabaseContext db)
        {
            _configuration = configuration;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("credentials")]
        public async Task<IActionResult> Post(UserInfo userData)
        {
            if (userData != null && userData.Email != null && userData.Password != null)
            {
                var user = _db.UserInfos.FirstOrDefault(x => x.Email == userData.Email && x.Password == userData.Password);
                if (user == null)
                {
                    return BadRequest("Invalid credentials");
                }
                var claims = new[]
                {
                      new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                      new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                      new Claim("UserId",user.UserId.ToString()),
                      new Claim("DisplayName",user.DisplayName),
                      new Claim("UserName",user.UserName),
                      new Claim("Email",user.Email)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

            else
            {
                return NotFound();
            }
        }


    }
}
