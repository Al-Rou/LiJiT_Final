using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LiJiT.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

 

namespace LiJiT.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenManagementController : ControllerBase
    {

    
        [HttpPost]
        [Route("Login")]
        public AuthenticationResult Login([FromBody] LoginModel loginModel)
        {

            AuthenticationResult responseModel = new AuthenticationResult();
            if (loginModel.UserName.Equals(JwtSettings.UserName) && loginModel.Password.Equals(JwtSettings.Password))
            {
                var jwtToken = GenerateJwtToken(loginModel.UserName);
                responseModel.Token = jwtToken;
                responseModel.Success = true;
            }
            else
            {
                responseModel.Success = false;
                responseModel.Errors = new List<string>();
                responseModel.Errors.Add("Username or Password is wrong!");
                return responseModel;
            }
            return responseModel;
        }
        private string GenerateJwtToken(string UserName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserName", UserName) }),
                Expires = DateTime.UtcNow.AddMinutes(JwtSettings.TokenLifetimeMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
