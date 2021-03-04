using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Content.Posts.Dtos
{
    public class PostListOutputDto:EntityDto<Guid>
    {
        #region Properties
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool Published { get; set; }
        public int? QueueNumber { get; set; }
        public string Url { get; set; }

        #endregion
    }
}
