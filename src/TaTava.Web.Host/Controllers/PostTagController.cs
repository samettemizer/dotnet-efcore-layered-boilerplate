using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.Content.PostsTags;
using TaTava.Content.PostsTags.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Web.Host.Controllers
{
    public class PostTagController : BaseApiController
    {
        private readonly IPostTagAppService _postTagAppService;
        public PostTagController(IPostTagAppService postTagAppService)
        {
            _postTagAppService = postTagAppService;
        }

        [HttpGet]
        public async Task<ServiceResult<IQueryable<PostTagListOutputDto>>> Get()
        {
            return await _postTagAppService.GetAll();
        }

        [HttpPost]
        public async Task<ServiceResult> Post(InsertPostTagInput input)
        {
            return await _postTagAppService.InsertPostTagInput(input);
        }

        [HttpDelete]
        public async Task<ServiceResult> Delete(EntityDto<Guid> input)
        {
            return await _postTagAppService.DeletePostTag(input);
        }
    }
}
