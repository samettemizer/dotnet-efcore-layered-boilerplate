using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaTava.Authentication;
using TaTava.Authentication.JwtBearer;
using TaTava.Authentications.Users.Dtos;
using TaTava.CommonTypes;
using TaTava.Infrastructure;
using TaTava.Mapper.Authorization;

namespace TaTava.Web.Host.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        private readonly IAuthenticationAppService _authenticationService;
        private readonly IJwtGenerator _jwtGenerator;

        public AuthenticationController(IAuthenticationAppService authenticationService, IJwtGenerator jwtGenerator)
        {
            _authenticationService = authenticationService;
            _jwtGenerator = jwtGenerator;
        }

        
        /// <summary>
        /// This is what it is!
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ServiceResult<LoggedinUserOutput>> Login(LoginInput input)
        {
            var serviceResult = await _authenticationService.Login(input);

            if (serviceResult.IsSucceed)
            {
                serviceResult.Object.Token = _jwtGenerator.GenerateToken(serviceResult.Object.ToUserLoggedInOutputClaims());
            }

            return serviceResult;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ServiceResult<LoggedinUserOutput>> Register(RegisterInput input)
        {
            var serviceResult = await _authenticationService.Register(input);

            if (serviceResult.IsSucceed)
            {
                //Login user to system
                var logingServiceResult = await _authenticationService.Login(new LoginInput { Email = input.Email, Password = input.Password });

                if (logingServiceResult.IsSucceed)
                {
                    logingServiceResult.Object.Token = _jwtGenerator.GenerateToken(logingServiceResult.Object.ToUserLoggedInOutputClaims());
                }

                return logingServiceResult;
            }

            return new ServiceResult<LoggedinUserOutput>(Status.Warning) { Message = serviceResult.Message };
        }

        [AllowAnonymous]
        [HttpGet("current-user")]
        public ServiceResult<LoggedinUserOutput> CurrentUser(string token)
        {
            try
            {
                var readedToken = _jwtGenerator.ReadToken(token);
                var tokenExpirationDate = readedToken.ValidTo;

                if (tokenExpirationDate > DateTime.Now)
                {
                    return new ServiceResult<LoggedinUserOutput>(Status.Success)
                    {
                        Message = "LoggedIn User",
                        Object = readedToken.Claims.ToLoggedInUserOutput(token)
                    };
                }
                else
                {
                    return new ServiceResult<LoggedinUserOutput>(Status.Warning)
                    {
                        Message = "Token is invalid!",
                        Object = { }
                    };
                }
            }
            catch
            {
                return new ServiceResult<LoggedinUserOutput>(Status.Warning)
                {
                    Message = "Token is invalid!",
                    Object = { }
                };
            }


        }
    }
}