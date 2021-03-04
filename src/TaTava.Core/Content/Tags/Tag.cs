using System;
using System.Collections.Generic;
using TaTava.Content.Posts;
using TaTava.Content.PostsTags;
using TaTava.Entities.Audited;
using TaTava.Policies;

namespace TaTava.Content.Tags
{
    public class Tag : AuditedEntity<Guid>
    {
        public Tag(string title)
        {
            SetTitle(title);
        }

        #region Properties

        public string Title { get; private set; }
        public string Url { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<PostTag> postTags { get; set; } = new List<PostTag>();


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