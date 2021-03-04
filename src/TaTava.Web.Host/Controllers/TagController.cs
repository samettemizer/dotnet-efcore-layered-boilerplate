using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.Content.Tags;
using TaTava.Content.Tags.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Web.Host.Controllers
{
    public class TagController : BaseApiController
    {
        private readonly ITagAppService _tagAppService;
        public TagController(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        [HttpGet]
        public async Task<ServiceResult<IQueryable<TagListOutputDto>>> Get()
        {
            return await _tagAppService.GetAllTag();
        }

        [HttpPost]
        public async Task<ServiceResult> Post(InsertTagInputDto input)
        {
            return await _tagAppService.InsertTagInput(input);
        }
        
        [HttpPut]
        public async Task<ServiceResult> Put(UpdateTagInputDto input)
        {
            return await _tagAppService.UpdateTagInput(input);
        }
        
        [HttpDelete]
        public async Task<ServiceResult> Delete(EntityDto<Guid> input)
        {
            return await _tagAppService.DeleteTag(input);
        }
    }
}
