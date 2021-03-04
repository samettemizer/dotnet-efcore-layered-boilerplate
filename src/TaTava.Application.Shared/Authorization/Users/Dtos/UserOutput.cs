using System;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Authorization.Users.Dtos
{
    public class UserOutput : EntityDto<Guid>
    {
        #region - Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        #endregion
    }
}