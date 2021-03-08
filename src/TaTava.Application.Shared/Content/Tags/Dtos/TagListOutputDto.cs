using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Content.Tags.Dtos
{
    public class TagListOutputDto : EntityDto<Guid>
    {
        #region Properties
        public string Title { get; set; }
        public string Url { get; set; }
        #endregion
    }
}
