using System;
using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Attachments
{
    public class Attachment : FullAuditedEntity<Guid>
    {
        public Attachment(string attachmentName)
        {
            SetAttachmentName(attachmentName);
        }

        #region Properties

        public string AttachmentName { get; private set; }

        public AttachmentType AttachmentType { get; set; }

        #endregion

        #region Navigation Properties 


            
        #endregion
    
        #region Domain Methods

        private void SetAttachmentName(string attachmentName)
        {
            Policy.NullOrWhiteSpaceCheck(attachmentName, nameof(attachmentName));
            AttachmentName = attachmentName;
        }

        #endregion
    }
}