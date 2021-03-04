using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Content.PostsTags.Dtos
{
    public class PostTagListOutputDto:EntityDto<Guid>
    {
        public Guid PostId { get; set; }
        public Guid TagId { get; set; }
    }
}
