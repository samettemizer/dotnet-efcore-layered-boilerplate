using System;
using TaTava.Categories;
using TaTava.Content.Posts;
using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Content.PostsCategories
{
    public class PostCategory : Entity<Guid>
    {
        //TODO: To example of how to do many to many relation for database. Check out: Core/Authentication/UserRoles/UserRole.cs, EntityFrameworkCore/EntityFrameworkCore/Configs/UserRoleConfiguration.cs

        public PostCategory(Guid postId, Guid categoryId)
        {
            SetPostId(postId);
            SetCategoryId(categoryId);
        }

        #region Properties
        #endregion

        #region Navigation Properties 

        public Guid PostId { get; private set; }
        public Post Post { get; set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; set; }

        #endregion

        #region Domain Properties
        public void SetPostId(Guid postId)
        {
            Policy.NullCheck(postId, nameof(postId));

            PostId = postId;
        }
        public void SetCategoryId(Guid categoryId)
        {
            Policy.NullCheck(categoryId, nameof(categoryId));

            CategoryId = categoryId;
        }
        #endregion
    }
}