using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.Content.PostsCategories;
using TaTava.Content.PostsCategories.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Web.Host.Controllers
{
    public class PostCategoryController:BaseApiController
    {
        private readonly IPostCategoryAppService _postCategoryAppService; 
        public PostCategoryController(IPostCategoryAppService postCategoryAppService)
        {
            _postCategoryAppService = postCategoryAppService;
        }

        [HttpGet]
        public async Task<ServiceResult<IQueryable<PostCategoryListOutputDto>>> Get()
        {
            return await _postCategoryAppService.GetAllPostCategory();
        }

        [HttpPost]
        public async Task<ServiceResult> Post(InsertPostCategoryInputDto input)
        {
            return await _postCategoryAppService.InsertPostCategoryInput(input);
        }
        
        [HttpDelete]
        public async Task<ServiceResult> Delete(EntityDto<Guid> input)
        {
            return await _postCategoryAppService.DeletePostCategory(input);
        }
    }
}
