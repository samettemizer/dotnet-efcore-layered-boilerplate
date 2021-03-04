using System;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Authorization.Users.Dtos
{
    public class UserListOutput : EntityDto<Guid>
    {
        #region - Properties

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #endregion
    }
}