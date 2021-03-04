using System;
using System.Threading.Tasks;
using TaTava.Authorization.UserAccounts;
using TaTava.CommonTypes;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;

namespace TaTava.Authorization.UserAccounts
{
    public class UserAccountPolicy : BasePolicy
    {
        private readonly IRepository<UserAccount, Guid> _userAccountRepository;

        public UserAccountPolicy(IRepository<UserAccount, Guid> userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<ServiceResult> SameEmailAddress(string emailAddress)
        {
            var isThisEmailUsedBySomeone = await _userAccountRepository.Any(userAccount => userAccount.Email == emailAddress);

            if (isThisEmailUsedBySomeone)
            {
                var errorMessage = $"Sistemde bu e-posta adı ile kayıtlı kullanıcı bulunmaktadır. E-posta Adresi: {emailAddress}";
                return new ServiceResult(Status.Warning) { Message = errorMessage };
            }

            return new ServiceResult(Status.Success);
        }
    }
}