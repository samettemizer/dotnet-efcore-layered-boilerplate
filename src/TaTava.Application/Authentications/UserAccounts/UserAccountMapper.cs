using System.Linq;
using TaTava.Authorization.UserAccounts;
using TaTava.Authorization.UserAccounts.Dtos;

namespace TaTava.Application.Authentications.UserAccounts
{
    public static class UserAccountMapper
    {
        public static IQueryable<UserAccountListOutput> ToUserAccountListOutput(this IQueryable<UserAccount> userAccounts)
        {
            return userAccounts.Select(userAccountListOutput => new UserAccountListOutput {
                Id = userAccountListOutput.Id,
                Email = userAccountListOutput.Email
            });
        }

        public static UserAccount ToUserAccountEntity(this InserUserAccountInput input)
        {
            return new UserAccount(input.Email, input.Password)
            {
            };
        }
    }
}