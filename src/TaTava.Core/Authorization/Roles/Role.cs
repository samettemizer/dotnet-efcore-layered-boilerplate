using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TaTava.Authorization.UserRoles;
using TaTava.Entities;

namespace TaTava.Authorization.Roles
{
    public class Role : FullAuditedEntity<Guid>
    {
        public Role(string roleName)
        {
            SetRoleName(roleName);
        }

        #region Properties

        public string RoleName { get; private set; }

        #endregion

        #region Navigation Properties

        [JsonIgnore]
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        #endregion

        #region DomainMethods

        public void SetRoleName(string roleName)
        {
            RoleName = roleName;
        }

        #endregion
    }
}