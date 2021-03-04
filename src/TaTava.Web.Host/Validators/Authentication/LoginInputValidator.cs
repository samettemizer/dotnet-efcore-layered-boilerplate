using TaTava.Authentications.Users.Dtos;
using TaTava.Extensions;

namespace TaTava.Web.Host.Validators.Authentication
{
    public class LoginInputValidator : BaseDtoValidator<LoginInput>
    {
        public LoginInputValidator()
        {
            RuleFor(login => login.Email)
                .EmailAddressCustom()
                .NullOrEmpty("E-posta");
            
            RuleFor(login => login.Password)
                .NullOrEmpty("Parola");
        }
    }
}