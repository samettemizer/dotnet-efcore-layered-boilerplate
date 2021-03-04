using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaTava.Application.Shared.Authorization.Users.Dtos;
using TaTava.Application.Shared.Dtos;
using TaTava.Authorization.Users;
using TaTava.Authorization.Users.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Web.Host.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        public async Task<ServiceResult<IQueryable<UserListOutput>>> Get()
        {
            return await _userAppService.GetUsers();
        }

        [HttpPost]
        public async Task<ServiceResult> Post(InsertUserInput input)
        {
            return await _userAppService.InsertUser(input);
        }

        [HttpPut]
        public async Task<ServiceResult> Put(UpdateUserInput input)
        {
            return await _userAppService.UpdateUser(input);
        }

        [HttpDelete]
        public async Task<ServiceResult> Delete(EntityDto<Guid> input)
        {
            return await _userAppService.DeleteUserById(input);
        }
    }
}