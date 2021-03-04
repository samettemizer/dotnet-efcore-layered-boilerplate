using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared;
using TaTava.Application.Shared.Dtos;
using TaTava.Content.Tags.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Content.Tags
{
    public interface ITagAppService:IApplicationService
    {
        Task<ServiceResult<IQueryable<TagListOutputDto>>> GetAllTag();
        Task<ServiceResult> InsertTagInput(InsertTagInputDto input);
        Task<ServiceResult> UpdateTagInput(UpdateTagInputDto input);
        Task<ServiceResult> DeleteTag(EntityDto<Guid> input);
    }
}
