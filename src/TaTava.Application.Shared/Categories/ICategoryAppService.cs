using System;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Infrastructure;
using TaTava.Application.Shared.Dtos;
using TaTava.Application.Shared;
using TaTava.Categories.Dtos;

namespace TaTava.Categories
{
    public interface ICategoryAppService : IApplicationService
    {
        Task<ServiceResult<IQueryable<CategoryListOutputDto>>> GetAllCategory();
        Task<ServiceResult> InsertCategory(InsertCategoryInputDto input);
        Task<ServiceResult> UpdateCategory(UpdateCategoryInputDto input);
        Task<ServiceResult> DeleteCategory(EntityDto<Guid> input);
    }
}