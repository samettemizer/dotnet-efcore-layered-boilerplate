using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TaTava.Content.PostsCategories;
using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Categories
{
    public class Category : FullAuditedEntity<Guid>
    {

        public Category(string title)
        {
            SetTitle(title);
        }

        #region Properties

        public string Title { get; private set; }
    
        #endregion

        #region Navigation Properties

        public Guid? UpperCategoryId { get; set; }

        [JsonIgnore]
        public virtual ICollection<PostCategory> postCategories { get; set; } = new List<PostCategory>();

        #endregion

        #region Domain Properties

        public void SetTitle(string title)
        {
            Policy.NullOrWhiteSpaceCheck(title, nameof(title));
            Title = title;
        }

        #endregion
    }
}