using System.Linq;
using TaTava.Authorization.UserAccounts.Dtos;
using TaTava.Authentications.Users.Dtos;
using TaTava.Authorization.Users.Dtos;
using System;
using TaTava.Application.Shared.Authorization.Users.Dtos;

namespace TaTava.Authorization.Users
{
    public static class UserMapper
    {
        public static User ToUserEntity(this InsertUserInput input, Guid userAccountId)
        {
            return new User(input.FirstName, input.LastName, userAccountId)
            {
                Address = input.Address,
                PhoneNumber = input.PhoneNumber
            };
        }

        public static UserOutput ToUserOutput(this User user)
        {
            return new UserOutput
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,

                UserAccountId = user.UserAccountId ?? Guid.NewGuid()
            };
        }

        public static User ToUpdatedUserEntity(this User user, UpdateUserInput input)
        {

            user.SetFirstName(input.FirstName);
            user.SetLastName(input.FirstName);

            user.Address = input.Address;
            user.PhoneNumber = input.PhoneNumber;

            return user;
        }

        public static LoggedinUserOutput ToUserLoggedInOutput(this User user)
        {
            return new LoggedinUserOutput
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public static IQueryable<UserListOutput> ToUserListOutput(this IQueryable<User> users)
        {
            return users.Select(userListOutput => new UserListOutput
            {
                Id = userListOutput.Id,
                FirstName = userListOutput.FirstName,
                LastName = userListOutput.LastName
            });
        }

        public static IQueryable<UserListOutput> ToUserListOutput(this IQueryable<User> users, IQueryable<UserAccountListOutput> userAccounts)
        {
            var abc = users.Select(userListOutput => new UserListOutput
            {
                Id = userListOutput.Id,
                FirstName = userListOutput.FirstName,
                LastName = userListOutput.LastName,
                Email = userAccounts.FirstOrDefault(userAccount => userAccount.Id == userListOutput.UserAccountId).Email
            });

            return abc;
        }

    }
}