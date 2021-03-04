using System;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Categories.Dtos
{
    public class CategoryOutputDto : EntityDto<Guid>
    {
        #region - Properties

        public string Title { get; set; }

        #endregion
    }
}
