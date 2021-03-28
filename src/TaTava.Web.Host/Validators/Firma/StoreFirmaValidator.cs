using FluentValidation;
using TaTava.Extensions;
using TaTava.Firmalar.Dtos;

namespace TaTava.Web.Host.Validators.Firma
{
    public class StoreFirmaValidator : BaseDtoValidator<FirmaInputDto>
    {
        public StoreFirmaValidator()
        {
            RuleFor(firma => firma.Unvan)
                .HasMinimumLength(10, "Unvan")
                .HasMaximumLength(200, "Unvan")
                .NullOrEmpty("foo bar baz");
            
        }
    }
}