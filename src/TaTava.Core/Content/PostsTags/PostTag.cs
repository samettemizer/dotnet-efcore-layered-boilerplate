using System;
using TaTava.Content.Posts;
using TaTava.Content.Tags;
using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Content.PostsTags
{
    public class PostTag : Entity<Guid>
    {
        public PostTag(Guid postId, Guid tagId)
        {
            SetPostId(postId);
            SetTagId(tagId);
        }
        //TODO: To example of how to do many to many relation for database. Check out: Core/Authentication/UserRoles/UserRole.cs, EntityFrameworkCore/EntityFrameworkCore/Configs/UserRoleConfiguration.cs
        #region Properties
        #endregion

        #region Navigation Properties

        public Guid PostId { get; private set; }
        public Post Post { get; set; }

        public Guid TagId { get; private set; }
        public Tag Tag { get; set; }

        #endregion

        #region Domain properties
        public void SetPostId(Guid postId)
        {
            Policy.NullCheck(postId, nameof(postId));
            PostId = postId;
        }
        public void SetTagId(Guid tagId)
        {
            Policy.NullCheck(tagId, nameof(tagId));
            TagId = tagId;
        }
        #endregion
    }
}