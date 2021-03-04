using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.Infrastructure;
using TaTava.Menus;
using TaTava.Menus.Dtos;

namespace TaTava.Web.Host.Controllers
{
    public class MenuController : BaseApiController
    {
        private readonly IMenuAppService _menuAppService;
        public MenuController(IMenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        }

        [HttpGet]
        public async Task<ServiceResult<IQueryable<MenuListOutputDto>>> Get()
        {
            return await _menuAppService.GetAllMenu();
        }

        [HttpGet("GetUserById")]
        public async Task<ServiceResult<MenuOutputDto>> Get(string id)
        {
            return await _menuAppService.GetMenuById(new EntityDto<Guid> { Id = Guid.Parse(id) });
        }

        [HttpPost]
        public async Task<ServiceResult> Post(InsertMenuInputDto input)
        {
            return await _menuAppService.InsertMenu(input);
        }

        [HttpPut]
        public async Task<ServiceResult> Put(UpdateMenuInputDto input)
        {
            return await _menuAppService.UpdateMenuInput(input);
        }

        [HttpDelete]
        public async Task<ServiceResult> Delete(EntityDto<Guid> input)
        {
            return await _menuAppService.DeleteMenu(input);
        }
    }
}
