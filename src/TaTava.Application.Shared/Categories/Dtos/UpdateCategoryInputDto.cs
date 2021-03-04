using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Categories.Dtos
{
    public class UpdateCategoryInputDto : EntityDto<Guid>
    {
        #region - Properties
        public string Title { get; set; }

        #endregion
    }
}
