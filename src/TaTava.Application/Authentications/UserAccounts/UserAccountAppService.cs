using System;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Authentications.UserAccounts;
using TaTava.Application.Shared.Authorization.UserAccounts;
using TaTava.Application.Shared.Dtos;
using TaTava.Authorization.UserAccounts;
using TaTava.Authorization.UserAccounts.Dtos;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;

namespace TaTava.Authentications.UserAccounts
{
    public class UserAccountAppService : BaseAppService, IUserAccountAppService
    {
        private readonly IRepository<UserAccount, Guid> _userAccountRepository;
        private readonly UserAccountPolicy _userAccountPolicy;

        public UserAccountAppService(IRepository<UserAccount, Guid> userAccountRepository, UserAccountPolicy userAccountPolicy)
        {
            _userAccountRepository = userAccountRepository;
            _userAccountPolicy = userAccountPolicy;
        }

        public async Task<ServiceResult> DeleteUserAccountById(EntityDto<Guid> input)
        {
            await _userAccountRepository.Delete(userAccount => userAccount.Id == input.Id);

            return new ServiceResult(Status.Success)
            {
                Message = string.Format(ServiceMessages.DeleteSuccessful, "Kullanıcı")
            };
        }

        public async Task<ServiceResult<IQueryable<UserAccountListOutput>>> GetAllUsersAccount()
        {
            var allUserAccounts = await _userAccountRepository.GetQueryableAsync();

            return new ServiceResult<IQueryable<UserAccountListOutput>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, allUserAccounts.Count(), "kullanıcı hesabı"),
                Object = allUserAccounts.ToUserAccountListOutput()
            };
        }

        public async Task<ServiceResult<Guid>> InserUserAccountAndReturnId(InserUserAccountInput input)
        {
            var isEmailAddressTakenBySomeone = await _userAccountPolicy.SameEmailAddress(input.Email);

            if (isEmailAddressTakenBySomeone.IsFailed)
                return new ServiceResult<Guid>(Status.Warning) { Message = isEmailAddressTakenBySomeone.Message };

            var addedUserAccountsId = await _userAccountRepository.InsertAndGetIdAsync(input.ToUserAccountEntity());

            return new ServiceResult<Guid>(Status.Success)
            {
                Message = string.Format(ServiceMessages.InsertSuccessful, "Kullanıcı"),
                Object = addedUserAccountsId
            };
        }


    }
}