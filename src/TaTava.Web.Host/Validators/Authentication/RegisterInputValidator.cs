using FluentValidation;
using TaTava.Authentications.Users.Dtos;
using TaTava.Extensions;

namespace TaTava.Web.Host.Validators.Authentication
{
    public class RegisterInputValidator : BaseDtoValidator<RegisterInput>
    {
        public RegisterInputValidator()
        {
            RuleFor(register => register.Email)
                .EmailAddress()
                .NullOrEmpty("E-posta");

            RuleFor(register => register.Password)
                .NullOrEmpty("Parola");

            RuleFor(register => register.ConfirmPassword)
                .Equal(register => register.ConfirmPassword).WithMessage("Doğrulama parolası, parola ile aynı olmalıdır!")
                .NullOrEmpty("Doğrulama Parolası");

            RuleFor(register => register.FirstName)
                .Firstname();
            
            RuleFor(register => register.FirstName)
                .LastName();

        }
    }
}