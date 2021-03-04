using System;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.Authorization.UserAccounts.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Application.Shared.Authorization.UserAccounts
{
    public interface IUserAccountAppService : IApplicationService
    {
         Task<ServiceResult<IQueryable<UserAccountListOutput>>> GetAllUsersAccount();
         Task<ServiceResult<Guid>> InserUserAccountAndReturnId(InserUserAccountInput input);
         Task<ServiceResult> DeleteUserAccountById(EntityDto<Guid> input);
    }
}