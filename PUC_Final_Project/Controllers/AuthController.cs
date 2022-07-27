using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PUC_Final_Project.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PUC_Final_Project.Controllers
{
    public class AuthController : Controller
    {

        [HttpPost, Route("login")]
        public IActionResult Login(Login model)
        {
            if (model == null)
            {
                return BadRequest("Invalid client request");
            }
            if (model.UserName == "henrique" && model.Password == "henrique123")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@2410"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "CodeMaze",
                    audience: "https://localhost:7245",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
