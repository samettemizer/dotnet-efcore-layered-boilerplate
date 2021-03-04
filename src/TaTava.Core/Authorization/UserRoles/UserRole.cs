using System;
using TaTava.Authorization.Roles;
using TaTava.Authorization.Users;
using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Authorization.UserRoles
{
    public class UserRole : FullAuditedEntity<Guid>
    {
        
        public UserRole(Guid userId, Guid roleId)
        {
            SetUserId(userId);
            SetRoleId(roleId);
        }

        #region Properties
        #endregion

        #region Navigation Properties

        public Guid UserId { get; private set; }
        public User User { get; set; }

        public Guid RoleId { get; private set; }
        public Role Role { get; set; }

        #endregion

        #region Domain Methods

        public void SetUserId(Guid userId)
        {
            Policy.NullCheck(userId, nameof(userId));
            UserId = userId;
        }

        public void SetRoleId(Guid roleId)
        {
            Policy.NullCheck(roleId, nameof(roleId));
            RoleId = roleId;
        }

        #endregion
    }
}