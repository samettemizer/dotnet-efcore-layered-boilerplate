using System;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Authorization.UserAccounts.Dtos
{
    public class UserAccountListOutput : EntityDto<Guid>
    {
        #region - Properties

        public string Email { get; set; }

        #endregion
    }
}