using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TaTava.Authentications.Users.Dtos;

namespace TaTava.Authentication.JwtBearer
{
    public interface IJwtGenerator
    {
        string GenerateToken(List<Claim> claims);
        JwtSecurityToken ReadToken(string token);
    }
}