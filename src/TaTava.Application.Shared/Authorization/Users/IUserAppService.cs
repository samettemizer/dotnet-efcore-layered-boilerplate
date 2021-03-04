using System;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared;
using TaTava.Application.Shared.Authorization.Users.Dtos;
using TaTava.Application.Shared.Dtos;
using TaTava.Authorization.Users.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Authorization.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<ServiceResult<IQueryable<UserListOutput>>> GetUsers();
        Task<ServiceResult> InsertUser(InsertUserInput input);
        Task<ServiceResult<UserOutput>> GetUserById(EntityDto<Guid> input);
        Task<ServiceResult> UpdateUser(UpdateUserInput input);
        Task<ServiceResult> DeleteUserById(EntityDto<Guid> input);
    }
}