using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IPT.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(AuthController));
        private string GenerateJWT(string userName, string role, string key)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim("UserName", userName),
                new Claim(ClaimTypes.Role, role)
            };
            var token = new JwtSecurityToken(
                claims: claims,
                issuer: "https://www.iptm.com",
                audience: "https://www.iptm.com",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
            );
            _log.Info("Generated JWT token");
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet]
        public ActionResult GetToken(string userName, string role, string key)
        {
            _log.Info("Token obtained");
            return Ok(GenerateJWT(userName, role, key));
        }
    }
}
