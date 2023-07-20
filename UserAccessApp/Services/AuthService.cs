using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using UserAccessApp.DBContext;
using UserAccessApp.Interface;
using UserAccessApp.Models;

namespace UserAccessApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserAccessDBContext _dbContext;

        private readonly IConfiguration _config;
        

        public AuthService(UserAccessDBContext dBContext, IConfiguration config)
        {
            _dbContext = dBContext;
            _config = config;
        }
        public JWTTokenResponse Authenticate(Login model)
        {
            var user = _dbContext.User.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);
            JWTTokenResponse jWTTokenResponse=new JWTTokenResponse();
            jWTTokenResponse.UserName=user.UserName;
            jWTTokenResponse.Toeken = token;
            return jWTTokenResponse;
        }


        private string generateJwtToken(User user)
        {
            string tokenstring=string.Empty;
            
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("UserName",user.UserName),
                new Claim("Role",user.Type.ToString())
            };
            var tokeOptions = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signinCredentials);
            tokenstring = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenstring;
        }
    }
}
