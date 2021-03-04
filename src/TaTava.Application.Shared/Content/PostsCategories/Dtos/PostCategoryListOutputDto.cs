using TaTava.Application.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaTava.Content.PostsCategories.Dtos
{
    public class PostCategoryListOutputDto:EntityDto<Guid>
    {
        public Guid PostId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
