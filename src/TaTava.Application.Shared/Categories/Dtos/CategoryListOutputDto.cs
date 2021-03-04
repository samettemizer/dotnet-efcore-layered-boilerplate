using System;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Categories.Dtos
{
    public class CategoryListOutputDto : EntityDto<Guid>
    {
        #region - Properties

        public string Title { get; set; }
        
        public DateTime CreationTime { get; set; }

        #endregion
    }
}