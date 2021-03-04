using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TaTava.Authorization.UserRoles;
using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Authorization.Users
{
    public class User : FullAuditedEntity<Guid>
    {
        public User(string firstName, string lastName, Guid? userAccountId)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetUserAccountId(userAccountId);
        }

        #region Properties

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        #endregion

        #region Navigation Properties

        public Guid? UserAccountId { get; private set; }

        [JsonIgnore]
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        #endregion

        #region Domain Methods

        public void SetFirstName(string firstName)
        {
            Policy.NullOrWhiteSpaceCheck(firstName, nameof(firstName));
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            Policy.NullOrWhiteSpaceCheck(lastName, nameof(lastName));
            LastName = lastName;
        }

        public void SetUserAccountId(Guid? userAccountId)
        {
            UserAccountId = userAccountId;
        }

        #endregion
    }

}