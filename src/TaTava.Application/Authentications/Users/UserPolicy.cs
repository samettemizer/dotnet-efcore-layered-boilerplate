using System;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.Authorization.Users;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;

namespace TaTava.Authentications.Users
{
    public class UserPolicy : BasePolicy
    {
        private readonly IRepository<User, Guid> _userRepository;

        public UserPolicy(IRepository<User, Guid> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResult> IsUserExistById(EntityDto<Guid> input)
        {
            var zeroCheck = input.Id == new Guid() ? false : true;

            if (!zeroCheck)
                return new ServiceResult(Status.Warning) { Message = ServiceMessages.RecordFound };

            var isUserExistInDatabaseById = await _userRepository.Any(user => user.Id == input.Id);
            if (!isUserExistInDatabaseById)
            {
                var errorMessage = $"Sistemde vermiş olduğunuz Id ile kayıtlı kullanıcı bulunmamaktadır, lütfen kontrol ediniz. Kullanıcı Id: {input.Id}";
                return new ServiceResult(Status.Warning) { Message = errorMessage };
            }

            return new ServiceResult(Status.Success);
        }
    }
}