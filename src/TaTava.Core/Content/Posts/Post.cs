using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TaTava.Attachments;
using TaTava.Content.PostsCategories;
using TaTava.Content.PostsTags;
using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Content.Posts
{
    public class Post : FullAuditedEntity<Guid>
    {
        public Post(string title, string content)
        {
            SetTitle(title);
            SetContent(content);
        }

        
        #region - Properties

        public string Title { get; private set; }
        public string Content { get; private set; }

        public DateTime? PublishDate { get; set; }
        public bool Published { get; set; }

        public int? QueueNumber { get; set; }

        //ToSeoUrl Uzantisi yazilacak.
        public string Url { get; set; }

        #endregion

        #region - Navigation Properties

        public Guid? AttachmentId { get; set; }

        public Attachment Attachment { get; set; }

        [JsonIgnore]
        public virtual ICollection<PostCategory> postCategories { get; set; } = new List<PostCategory>();

        [JsonIgnore]
        public virtual ICollection<PostTag> postTags { get; set; } = new List<PostTag>();

        #endregion

        #region Domain Properties
        public void SetTitle(string title)
        {
            Policy.NullOrWhiteSpaceCheck(title,nameof(title));
            Title = title;
        }
        public void SetContent(string content)
        {
            Policy.NullOrWhiteSpaceCheck(content, nameof(content));
            Content = content;
        }
        #endregion

    }
}