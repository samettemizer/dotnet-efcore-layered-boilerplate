using System;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Authorization.UserAccounts.Dtos
{
    public class InserUserAccountInput : EntityDto
    {
        #region - Properties

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        #endregion
    }
}