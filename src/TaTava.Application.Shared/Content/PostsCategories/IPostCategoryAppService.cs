using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared;
using TaTava.Application.Shared.Dtos;
using TaTava.Content.PostsCategories.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Content.PostsCategories
{
    public interface IPostCategoryAppService:IApplicationService
    {
        Task<ServiceResult<IQueryable<PostCategoryListOutputDto>>> GetAllPostCategory();
        Task<ServiceResult> InsertPostCategoryInput(InsertPostCategoryInputDto input);
        Task<ServiceResult> DeletePostCategory(EntityDto<Guid> input);
    }
}
