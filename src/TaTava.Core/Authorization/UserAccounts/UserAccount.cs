using System;
using System.ComponentModel.DataAnnotations;
using TaTava.Core.MetaDatas;
using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Authorization.UserAccounts
{
    [MetadataType(typeof(UserAccountMetaData))]
    public class UserAccount : FullAuditedEntity<Guid>
    {
        public UserAccount(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
        }

        #region Properties

        public string Email { get; private set; }
        public string Password { get; private set; }

        #endregion

        #region Navigation Properties
        #endregion

        #region Domain Methods

        public void SetEmail(string email)
        {
            Policy.NullOrWhiteSpaceCheck(email, nameof(email));
            Email = email;
        }

        public void SetPassword(string password)
        {
            Policy.NullOrWhiteSpaceCheck(password, nameof(password));
            Password = password;
        }

        #endregion
    }
}