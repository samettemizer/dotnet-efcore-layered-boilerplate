using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TaTava.Consts;

namespace TaTava.Extensions
{
    public static class FluentValidationExtensions
    {
        public static string NotEmptyMessage = "{0} alanı boş olamaz";
        public static string MinimumLength = "Minimum {0} karakter girebilirsiniz.";
        public static string MaximumLength = "Maksimum {0} karakter girebilirsiniz.";
        public static string Length = "{0} karakter girmeniz gerekmektedir.";
        public static string WrongFormat = "Hatalı formatta giriş yaptınız. Lütfen doğru format girişi yaptığınıza emin olun.";
        public static string ListCount = "{0} listesinde en az bir elemen bulunmalıdır.";

        public static void AddFluentValidator<T1, T2>(this IServiceCollection services) where T1 : class where T2 : class
        {
            services.AddTransient(typeof(IValidator<T1>), typeof(T2));
        }
        public static IRuleBuilderOptions<T, string> Firstname<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage(x => string.Format(NotEmptyMessage, "Ad"))
                .MaximumLength(50).WithMessage(string.Format(MaximumLength, 50))
                .Matches(Regexs.OnlyStringRegex).WithMessage(WrongFormat);
        }
        public static IRuleBuilderOptions<T, string> LastName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage(string.Format(NotEmptyMessage, "Soyad"))
                .MaximumLength(50).WithMessage(string.Format(MaximumLength, 50))
                .Matches(Regexs.OnlyStringRegex).WithMessage(WrongFormat);
        }
        public static IRuleBuilderOptions<T, string> PhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Length(10).WithMessage(string.Format(NotEmptyMessage, "10"))
                .Matches(Regexs.PhoneNumberRegex).WithMessage("Geçersiz telefon formatı 10 karakter girmelisiniz. Örn : 3124443322");
        }
        public static IRuleBuilderOptions<T, string> EmailAddressCustom<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage(string.Format(NotEmptyMessage, "E-Posta"))
                .Matches(Regexs.EmailRegex).WithMessage(WrongFormat);
        }

        public static IRuleBuilderOptions<T, string> CellPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Length(10).WithMessage(string.Format(NotEmptyMessage, "10"))
                .Matches(Regexs.CellPhoneNumberRegex).WithMessage("Geçersiz telefon formatı 10 karakter girmelisiniz. Örn : 5554443322");
        }
        public static IRuleBuilderOptions<T, string> SecurePassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Length(8, 15).WithMessage("Geçersiz şifre formatı en az 8 en fazla 15 karakter girmelisiniz.")
                .Matches(Regexs.SecurePasswordRegex).WithMessage("Geçersiz şifre formatı en az 8 en fazla 15 karakter girmelisiniz içerisinde en az 1 tane özel karakter içermelidir.");
        }
        public static IRuleBuilderOptions<T, string> SecurePin<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Length(4).WithMessage("4 haneli pin giriniz.")
                .Matches(Regexs.SecurePinRegex).WithMessage("Geçersiz pin formatı 9999 gibi 4 haneli giriniz.");
        }
        public static IRuleBuilderOptions<T, string> Number<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Matches(Regexs.OnlyNumberRegex).WithMessage("Sadece sayı girilebilir.");
        }
        public static IRuleBuilderOptions<T, string> Identification<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Matches(Regexs.IdentityRegex).WithMessage("Geçersiz T.C. kimlik numarası formatı girdiniz. Lütfen 11 haneden oluşan T.C. kimlik numaranızı giriniz.");
        }

        /// <param name="propertyName">Validasyon başarısız olursa ekrana yazılmasını istediğiniz değeri girin. Örn. "Kullanıcı Adı"</param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> NullOrEmpty<T>(this IRuleBuilder<T, string> ruleBuilder, string propertyName)
        {
            return ruleBuilder
                .NotNull().WithMessage(string.Format(FluentValidationExtensions.NotEmptyMessage, propertyName));
        }

        /// <param name="propertyName">Validasyon başarısız olursa ekrana yazılmasını istediğiniz değeri girin. Örn. "Kullanıcı Adı"</param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, bool> NullOrEmpty<T>(this IRuleBuilder<T, bool> ruleBuilder, string propertyName)
        {
            return ruleBuilder
                .NotNull().WithMessage(string.Format(FluentValidationExtensions.NotEmptyMessage, propertyName));
        }

        /// <param name="propertyName">Validasyon başarısız olursa ekrana yazılmasını istediğiniz değeri girin. Örn. "Kullanıcı Adı"</param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, TProperty> Enum<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string propertyName) where TProperty : Enum
        {
            return ruleBuilder
            .NotNull().WithMessage(string.Format(FluentValidationExtensions.NotEmptyMessage, propertyName))
            .IsInEnum().WithMessage(string.Format(FluentValidationExtensions.WrongFormat, propertyName));
        }


        /// <param name="propertyName">Validasyon başarısız olursa ekrana yazılmasını istediğiniz değeri girin. Örn. "Kullanıcı Adı"</param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, TProperty> DateTime<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string propertyName)
        {
            return ruleBuilder
                .NotNull().WithMessage(x => string.Format(NotEmptyMessage, propertyName))
                .Must(x => x.GetType() == typeof(DateTime)).WithMessage("Geçersiz tarih formatı girdiniz.");
        }

        public static IRuleBuilderOptions<T, string> HasMaximumLength<T>(this IRuleBuilder<T, string> ruleBuilder, int length, string propertyName)
        {
            return ruleBuilder
                .NotNull().WithMessage(string.Format(FluentValidationExtensions.NotEmptyMessage, propertyName))
                .MaximumLength(length).WithMessage(string.Format(FluentValidationExtensions.MaximumLength, propertyName));
        }

        public static IRuleBuilderOptions<T, string> HasMinimumLength<T>(this IRuleBuilder<T, string> ruleBuilder, int length, string propertyName)
        {
            return ruleBuilder
                .NotNull().WithMessage(string.Format(FluentValidationExtensions.NotEmptyMessage, propertyName))
                .MinimumLength(length).WithMessage(string.Format(FluentValidationExtensions.MinimumLength, propertyName));
        }

    }
}
