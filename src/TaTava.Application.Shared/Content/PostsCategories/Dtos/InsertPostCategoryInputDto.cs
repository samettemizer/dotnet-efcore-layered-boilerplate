using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Content.PostsCategories.Dtos
{
    public class InsertPostCategoryInputDto:EntityDto<Guid>
    {
        public Guid PostId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
