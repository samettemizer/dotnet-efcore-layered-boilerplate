
using System;
using System.Threading.Tasks;
using TaTava.Authorization.UserAccounts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.Authorization.Users;
using TaTava.Authentications.Users.Dtos;
using Microsoft.Extensions.Configuration;
using TaTava.Core.Security;
using TaTava.Mapper.Authorization;
using TaTava.Firmalar;
using TaTava.Application.Firmalar;

namespace TaTava.Authentication
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserAccount, Guid> _userAccountRepository;
        private readonly IRepository<User, Guid> _userRepository;
        private readonly IRepository<Firma, int> _firmaRepository;
        private readonly UserAccountPolicy _userAccountPolicy;
        private readonly IEncryption _encryption;
        private readonly IConfiguration _config;

        public AuthenticationAppService(IUnitOfWork unitOfWork, IRepository<UserAccount, Guid> userAccountRepository, IRepository<User, Guid> userRepository, IRepository<Firma, int> firmaRepository, UserAccountPolicy userAccountPolicy, IEncryption encryption, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _userAccountRepository = userAccountRepository;
            _userRepository = userRepository;
            _firmaRepository = firmaRepository;
            _userAccountPolicy = userAccountPolicy;
            _encryption = encryption;

            _config = config;
        }

        public async Task<ServiceResult<LoggedinUserOutput>> Login(LoginInput input)
        {
            input.Password = _encryption.EncryptText(input.Password);
            var userAccount = await _userAccountRepository.GetAsync(userAccount => userAccount.Email == input.Email && userAccount.Password == input.Password);

            if (userAccount is null)
            {
                return new ServiceResult<LoggedinUserOutput>(Status.Warning)
                {
                    Message = ServiceMessages.RecordNotFound
                };
            }

            var userFromUserAccountId = await _userRepository.GetAsync(user => user.UserAccountId == userAccount.Id);

            var userLoggedInOutput = userFromUserAccountId.ToUserLoggedInOutput();

            var usersFirma = await _firmaRepository.GetAsync(firma => firma.FirmaYetkiliKullaniciId == userFromUserAccountId.Id);

            if (usersFirma is not null)
            {
                userLoggedInOutput.Firma = usersFirma.ToFirmaOutputDto();
            }

            return new ServiceResult<LoggedinUserOutput>(Status.Success)
            {
                Message = ServiceMessages.Successful,
                Object = userLoggedInOutput
            };
        }

        public async Task<ServiceResult<RegisteredUserOutput>> Register(RegisterInput input)
        {
            var isEmailAddressTakenBySomeone = await _userAccountPolicy.SameEmailAddress(input.Email);

            if (isEmailAddressTakenBySomeone.IsFailed)
                return new ServiceResult<RegisteredUserOutput>(Status.Warning) { Message = isEmailAddressTakenBySomeone.Message };

            try
            {
                using (var transaction = _unitOfWork.BeginTransaction())
                {
                    var userAccountId = await _userAccountRepository.InsertAndGetIdAsync(input.ToUserAccountEntity());

                    await _userRepository.InsertAsync(input.ToUserEntity(userAccountId));

                    _unitOfWork.SaveChanges();

                    transaction.Commit();
                }

                return new ServiceResult<RegisteredUserOutput>(Status.Success) { Message = "Kullanıcı kaydı başarılı." };
            }
            catch (Exception e)
            {
                return new ServiceResult<RegisteredUserOutput>(Status.Error) { Message = string.Format("Kullanıcı kaydı sırasında bir hata oluştu. Sebebi; {0}", e.Message) };
            }

        }

        //TODO: Reset Password endpoint should be done.
        
    }
}