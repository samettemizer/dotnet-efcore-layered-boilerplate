using System.Threading.Tasks;
using TaTava.Application.Shared;
using TaTava.Authorization.Users.Dtos;
using TaTava.Authentications.Users.Dtos;
using TaTava.Infrastructure;
using System.Collections.Generic;
using System.Security.Claims;

namespace TaTava.Authentication
{
    public interface IAuthenticationAppService : IApplicationService
    {
        Task<ServiceResult<LoggedinUserOutput>> Login(LoginInput input);
        Task<ServiceResult<RegisteredUserOutput>> Register(RegisterInput input);
    }
}