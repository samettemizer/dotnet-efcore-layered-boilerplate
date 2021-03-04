using System;
using TaTava.Application.Shared.Dtos;
using TaTava.Authorization.UserAccounts.Dtos;

namespace TaTava.Authorization.Users.Dtos
{
    public class InsertUserInput : EntityDto
    {
        #region - Properties
        
        public InserUserAccountInput UserAccount { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        
        #endregion
    }
}