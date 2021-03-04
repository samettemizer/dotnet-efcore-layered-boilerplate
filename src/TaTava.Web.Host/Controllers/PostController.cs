using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.Content.Posts;
using TaTava.Content.Posts.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Web.Host.Controllers
{
    public class PostController : BaseApiController
    {
        private readonly IPostAppService _postAppService;

        public PostController(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        [HttpGet]
        public async Task<ServiceResult<IQueryable<PostListOutputDto>>> Get()
        {
            return await _postAppService.GetAllPosts();
        }

        [HttpPost]
        public async Task<ServiceResult> Post(InsertPostInputDto input)
        {
            return await _postAppService.InsertPostInput(input);
        }

        [HttpPut]
        public async Task<ServiceResult> Put(UpdatePostInputDto input)
        {
            return await _postAppService.UpdatePostInput(input);
        }

        [HttpDelete]
        public async Task<ServiceResult> Delete(EntityDto<Guid> input)
        {
            return await _postAppService.DeletePost(input);
        }


    }
}
