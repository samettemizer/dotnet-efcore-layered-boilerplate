using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.Categories;
using TaTava.Categories.Dtos;
using TaTava.Infrastructure;


namespace TaTava.Web.Host.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet]
        public async Task<ServiceResult<IQueryable<CategoryListOutputDto>>> Get()
        {
            return await _categoryAppService.GetAllCategory();
        }

        [HttpPost]
        public async Task<ServiceResult> Post(InsertCategoryInputDto input)
        {
            return await _categoryAppService.InsertCategory(input);
        }

        [HttpPut]
        public async Task<ServiceResult> Put(UpdateCategoryInputDto input)
        {
            return await _categoryAppService.UpdateCategory(input);
        } 

        [HttpDelete]
        public async Task<ServiceResult> Delete(EntityDto<Guid> input)
        {
            return await _categoryAppService.DeleteCategory(input);
        }
    }
}
