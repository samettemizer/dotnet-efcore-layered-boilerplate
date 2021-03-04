using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TaTava.Authentications.Users.Dtos;
using TaTava.Authorization.UserAccounts;
using TaTava.Authorization.Users;

namespace TaTava.Mapper.Authorization
{
    public static class AutheticationMapper
    {
        public static List<Claim> ToUserLoggedInOutputClaims(this LoggedinUserOutput userLoggedInOutput)
        {
            return new List<Claim>()
                {
                    new Claim("Id", userLoggedInOutput.Id.ToString()),
                    new Claim("firstName", userLoggedInOutput.FirstName),
                    new Claim("lastName", userLoggedInOutput.LastName)
                };
        }

        public static UserAccount ToUserAccountEntity(this RegisterInput input)
        {
            var userAccount = new UserAccount(input.Email, input.Password);
            return userAccount;
        }

        public static User ToUserEntity(this RegisterInput input, Guid userAccountId)
        {
            var user = new User(input.FirstName, input.LastName, userAccountId)
            {
                Address = input.Address,
                PhoneNumber = input.PhoneNumber,
            };
            return user;
        }

        public static LoggedinUserOutput ToLoggedInUserOutput(this IEnumerable<Claim> tokenClaims, string token)
        {
            return new LoggedinUserOutput
            {
                Id = new Guid(tokenClaims.FirstOrDefault(claim => claim.Type == "Id").Value),
                FirstName = tokenClaims.FirstOrDefault(claim => claim.Type == "firstName").Value,
                LastName = tokenClaims.FirstOrDefault(claim => claim.Type == "lastName").Value,
                Token = token
            };
        }
    }
}