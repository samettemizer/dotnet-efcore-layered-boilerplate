using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared;
using TaTava.Application.Shared.Dtos;
using TaTava.Content.Posts.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Content.Posts
{
    public interface IPostAppService:IApplicationService
    {
        Task<ServiceResult<IQueryable<PostListOutputDto>>> GetAllPosts();
        Task<ServiceResult> InsertPostInput(InsertPostInputDto input);
        Task<ServiceResult> UpdatePostInput(UpdatePostInputDto input);
        Task<ServiceResult> DeletePost(EntityDto<Guid> input);
    }
}
