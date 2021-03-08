using System;
using System.Collections.Generic;
using System.Security.Claims;
using TaTava.Application.Shared.Dtos;
using TaTava.Firmalar.Dtos;

namespace TaTava.Authentications.Users.Dtos
{
    public class LoggedinUserOutput : EntityDto<Guid>
    {
        //Personal Informations
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public FirmaOutputDto Firma { get; set; }

        //System Informations
        public string Token { get; set; }
    }
}