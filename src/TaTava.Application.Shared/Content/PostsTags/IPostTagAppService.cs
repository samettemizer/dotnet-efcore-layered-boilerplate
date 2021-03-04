using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared;
using TaTava.Application.Shared.Dtos;
using TaTava.Content.PostsTags.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Content.PostsTags
{
    public interface IPostTagAppService:IApplicationService
    {
        Task<ServiceResult<IQueryable<PostTagListOutputDto>>> GetAll();
        Task<ServiceResult> InsertPostTagInput(InsertPostTagInput input);
        Task<ServiceResult> DeletePostTag(EntityDto<Guid> input);
    }
}
