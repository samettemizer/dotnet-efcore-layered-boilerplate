using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaTava.Authentication.Web.JwtBearer;
using TaTava.Authentications.Users.Dtos;
using TaTava.Configuration;

namespace TaTava.Authentication.JwtBearer
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public JwtGenerator(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = env.GetAppConfiguration();
            _hostingEnvironment = env;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerateToken(List<Claim> claims)
        {
            var jwtConfig = _configuration.GetSection("AuthenticationConfigurations").Get<JwtTokenConfig>();

            var tokenHandler = new JwtSecurityTokenHandler();
            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret)), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(jwtConfig.AccessTokenExpiration),
                SigningCredentials = credentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

        public JwtSecurityToken ReadToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.ReadJwtToken(token);
        }
    }
}