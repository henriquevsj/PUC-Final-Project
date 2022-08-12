using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PUC_Final_Project.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PUC_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurancaController : ControllerBase
    {
        private readonly IConfiguration _config;
        public SegurancaController(IConfiguration configuration)
        {
            _config = configuration;
        }
        [HttpPost]
        public IActionResult Login([FromBody] User loginDetails)
        {
            bool resultado = ValidarUsuario(loginDetails);
            if (resultado)
            {
                var tokenString = GerarTokenJwt();
                return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        [NonAction]
        private bool ValidarUsuario(User loginDetails)
        {
            if (loginDetails.UserName == "mac" && loginDetails.Password == "numsey")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [NonAction]
        public string GerarTokenJwt()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(60);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
