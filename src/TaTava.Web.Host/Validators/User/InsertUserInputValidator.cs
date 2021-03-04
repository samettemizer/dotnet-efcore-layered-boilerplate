using FluentValidation;
using TaTava.Authorization.Users.Dtos;
using TaTava.Extensions;

namespace TaTava.Web.Host.Validators.User
{
    public class InsertUserInputValidator : BaseDtoValidator<InsertUserInput>
    {
        public InsertUserInputValidator()
        {
             RuleFor(user => user.UserAccount.Email)
                .EmailAddress()
                .NullOrEmpty("E-posta");

            RuleFor(user => user.UserAccount.Password)
                .NullOrEmpty("Parola");

            RuleFor(user => user.UserAccount.ConfirmPassword)
                .Equal(user => user.UserAccount.ConfirmPassword).WithMessage("Doğrulama parolası, parola ile aynı olmalıdır!")
                .NullOrEmpty("Doğrulama Parolası");

            RuleFor(user => user.FirstName)
                .Firstname();
            
            RuleFor(user => user.LastName)
                .LastName();
                
        }
    }
}