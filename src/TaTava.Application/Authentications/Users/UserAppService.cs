using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TaTava.Application.Shared.Authorization.UserAccounts;
using TaTava.Application.Shared.Authorization.Users.Dtos;
using TaTava.Application.Shared.Dtos;
using TaTava.Authentications.Users;
using TaTava.Authorization.Users.Dtos;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;

namespace TaTava.Authorization.Users
{
    public class UserAppService : BaseAppService, IUserAppService
    {
        private readonly IRepository<User, Guid> _userRepository;
        private readonly UserPolicy _userPolicy;
        private readonly IUnitOfWork _unitOfWork;

        public UserAppService(IRepository<User, Guid> userRepository, UserPolicy userPolicy, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _userRepository = userRepository;
            _userPolicy = userPolicy;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult> DeleteUserById(EntityDto<Guid> input)
        {
            var userById = await _userRepository.GetAsync(user => user.Id == input.Id);

            if (userById is null)
                return new ServiceResult(Status.Warning)
                {
                    Message = ServiceMessages.RecordNotFound
                };

            try
            {
                await _userRepository.Delete(user => user.Id == input.Id);

                var userAccountService = GetService<IUserAccountAppService>();
                await userAccountService.DeleteUserAccountById(new EntityDto<Guid> { Id = (Guid)userById.UserAccountId });

                _unitOfWork.SaveChanges();

                return new ServiceResult(Status.Success)
                {
                    Message = string.Format(ServiceMessages.DeleteSuccessful, "Kullanıcı")
                };
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<ServiceResult<UserOutput>> GetUserById(EntityDto<Guid> input)
        {
            var userById = await _userRepository.GetAsync(user => !user.IsDeleted && user.Id == input.Id);

            if (userById is null)
                return new ServiceResult<UserOutput>(Status.Warning)
                {
                    Message = ServiceMessages.RecordNotFound
                };

            return new ServiceResult<UserOutput>(Status.Success)
            {
                Message = ServiceMessages.RecordFound,
                Object = userById.ToUserOutput()
            };
        }

        public async Task<ServiceResult<IQueryable<UserListOutput>>> GetUsers()
        {
            var allUsers = await _userRepository.GetQueryableAsync(user => !user.IsDeleted);

            var userAccountService = GetService<IUserAccountAppService>();
            var allUserAccount = await userAccountService.GetAllUsersAccount();

            return new ServiceResult<IQueryable<UserListOutput>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, allUsers.Count(), "kullanıcı"),
                Object = allUsers.ToUserListOutput(allUserAccount.Object)
            };
        }

        public async Task<ServiceResult<UserOutput>> InsertUser(InsertUserInput input)
        {
            try
            {
                using (var transaction = _unitOfWork.BeginTransaction())
                {

                    var userAccountId = await GetService<IUserAccountAppService>().InserUserAccountAndReturnId(input.UserAccount);

                    if (userAccountId.IsFailed)
                        return new ServiceResult<UserOutput>(userAccountId.Status)
                        {
                            Message = userAccountId.Message
                        };

                    var userEntity = input.ToUserEntity(userAccountId.Object);
                    await _userRepository.InsertAsync(userEntity);

                    _unitOfWork.SaveChanges();

                    transaction.Commit();

                    return new ServiceResult<UserOutput>(Status.Success) { Message = "Kullanıcı kaydı başarılı.", Object = userEntity.ToUserOutput() };
                }

            }
            catch (Exception e)
            {
                return new ServiceResult<UserOutput>(Status.Error) { Message = string.Format("Kullanıcı kaydı sırasında bir hata oluştu. Sebebi; {0}", e.Message) };
            }
        }

        public async Task<ServiceResult> UpdateUser(UpdateUserInput input)
        {
            var isUserExistById = await _userPolicy.IsUserExistById(new EntityDto<Guid> { Id = input.Id });

            if (isUserExistById.IsFailed)
                return new ServiceResult(isUserExistById.Status)
                {
                    Message = isUserExistById.Message
                };

            var userToUpdate = await _userRepository.GetAsync(user => user.Id == input.Id);

            try
            {
                await _userRepository.Update(userToUpdate.ToUpdatedUserEntity(input));

                _unitOfWork.SaveChanges();

                return new ServiceResult<UpdateUserInput>(Status.Success) { Message = $"{input.FirstName} adlı kullanıcının bilgileri güncellenmiştir.", Object = input };
            }
            catch (Exception e)
            {
                return new ServiceResult<UpdateUserInput>(Status.Error) { Message = string.Format($"{input.FirstName} adlı kullanıcının bilgilerini düzenlerken bir hata oluştu. Sebebi; {0}", e.Message) };
            }

        }
    }
}