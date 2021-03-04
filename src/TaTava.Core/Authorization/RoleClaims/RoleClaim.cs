using System;
using TaTava.Authorization.Roles;
using TaTava.Entities.Audited;
using TaTava.Policies;

namespace TaTava.Authorization.RoleClaims
{
    public class RoleClaim : AuditedEntity<Guid>
    {
        public RoleClaim(string permissionName, Guid roleId)
        {
            SetPermissionName(permissionName);
            SetRoleId(roleId);
        }

        #region Properties

        public string PermissionName { get; set; }

        #endregion

        #region Navigation Properties

        public Guid RoleId { get; private set; }
        public Role Role { get; set; }

        #endregion

        #region Domain Methods

        public void SetPermissionName(string permissionName)
        {
            Policy.NullOrWhiteSpaceCheck(permissionName, nameof(permissionName));
            PermissionName = permissionName;
        }

        public void SetRoleId(Guid roleId)
        {
            Policy.NewGuidCheck(roleId, nameof(roleId));
            RoleId = roleId;
        }

        #endregion
    }
}