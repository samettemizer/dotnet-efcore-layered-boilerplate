
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TaTava.Application.Shared;
using TaTava.CommonTypes;

namespace TaTava.Infrastructure
{
    public class BaseAppService
    {
        public BaseAppService()
        {

        }

        private readonly IHttpContextAccessor _httpContextAccessor;
        public BaseAppService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IServiceProvider Resolver => _httpContextAccessor?.HttpContext?.RequestServices;

        public T GetService<T>() where T : IApplicationService
        {
            if (Resolver == null)
                return default;

            return Resolver.GetService<T>();
        }

        public ServiceResult CreateSuccessServiceResult(string message = null)
        {
            return string.IsNullOrWhiteSpace(message)
                ? new ServiceResult(Status.Success)
                : new ServiceResult(Status.Success) { Message = message };
        }

        public ServiceResult CreateErrorServiceResult(string message = null)
        {
            return string.IsNullOrWhiteSpace(message)
                ? new ServiceResult(Status.Error)
                : new ServiceResult(Status.Error) { Message = message };
        }
    }
}