using System;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Application.Shared.Authorization.Users.Dtos
{
    public class UpdateUserInput : EntityDto<Guid>
    {
        #region - Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        #endregion
    }
}