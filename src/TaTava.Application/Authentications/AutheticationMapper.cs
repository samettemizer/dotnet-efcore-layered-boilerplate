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
            var userClaims = new List<Claim>()
                {
                    new Claim("Id", userLoggedInOutput.Id.ToString()),
                    new Claim("firstName", userLoggedInOutput.FirstName),
                    new Claim("lastName", userLoggedInOutput.LastName)
                };

            if (userLoggedInOutput.Firma is not null)
            {
                userClaims.AddRange(new List<Claim>()
                {
                    new Claim("firmaId", userLoggedInOutput.Firma.Id.ToString()),
                    new Claim("unvan", userLoggedInOutput.Firma.Unvan),
                    new Claim("yetkiliAd", userLoggedInOutput.Firma.YetkiliAd),
                    new Claim("yetkiliSoyad", userLoggedInOutput.Firma.YetkiliSoyad),
                    new Claim("telefon", userLoggedInOutput.Firma.Telefon),
                    new Claim("mobileTelefon", userLoggedInOutput.Firma.MobilTelefon),
                    new Claim("faks", userLoggedInOutput.Firma.Faks),
                    new Claim("adres", userLoggedInOutput.Firma.Adres),
                    new Claim("googleHarita", userLoggedInOutput.Firma.GoogleHarita?.ToString()),
                    new Claim("ilId", userLoggedInOutput.Firma.IlId.ToString()),
                    new Claim("ilceId", userLoggedInOutput.Firma.IlceId.ToString()),
                    new Claim("sektorId", userLoggedInOutput.Firma.SektorId.ToString()),
                });
            }

            return userClaims;
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
                Firma = new()
                {
                    Unvan = tokenClaims.FirstOrDefault(claim => claim.Type == "adres")?.Value,
                    YetkiliAd = tokenClaims.FirstOrDefault(claim => claim.Type == "yetkiliAd")?.Value,
                    YetkiliSoyad = tokenClaims.FirstOrDefault(claim => claim.Type == "yetkiliSoyad")?.Value,
                    Telefon = tokenClaims.FirstOrDefault(claim => claim.Type == "telefon")?.Value,
                    MobilTelefon = tokenClaims.FirstOrDefault(claim => claim.Type == "mobileTelefon")?.Value,
                    Faks = tokenClaims.FirstOrDefault(claim => claim.Type == "faks")?.Value,
                    Adres = tokenClaims.FirstOrDefault(claim => claim.Type == "adres")?.Value,
                    GoogleHarita = tokenClaims.FirstOrDefault(claim => claim.Type == "googleHarita")?.Value,
                    IlId = !string.IsNullOrEmpty(tokenClaims.FirstOrDefault(claim => claim.Type == "ilId")?.Value) ? Convert.ToInt16(tokenClaims.FirstOrDefault(claim => claim.Type == "ilId")?.Value) : 1,
                    IlceId = !string.IsNullOrEmpty(tokenClaims.FirstOrDefault(claim => claim.Type == "ilceId")?.Value) ? Convert.ToInt16(tokenClaims.FirstOrDefault(claim => claim.Type == "ilceId")?.Value) : 1,
                    SektorId = !string.IsNullOrEmpty(tokenClaims.FirstOrDefault(claim => claim.Type == "sektorId")?.Value) ? Convert.ToInt16(tokenClaims.FirstOrDefault(claim => claim.Type == "sektorId")?.Value) : 3,
                },
                Token = token
            };
        }
    }
}