using Microsoft.Extensions.DependencyInjection;
using TaTava.Application.Infrastructure;
using TaTava.Authentication.JwtBearer;
using TaTava.Authentications.Users.Dtos;
using TaTava.Authorization.Users.Dtos;
using TaTava.Categories.Dtos;
using TaTava.Content.Posts.Dtos;
using TaTava.Content.Tags.Dtos;
using TaTava.Extensions;
using TaTava.Menus.Dtos;
using TaTava.Sliders.Dtos;
using TaTava.Web.Host.Validators.Authentication;
using TaTava.Web.Host.Validators.Category;
using TaTava.Web.Host.Validators.Content.Post;
using TaTava.Web.Host.Validators.Content.Tag;
using TaTava.Web.Host.Validators.Menu;
using TaTava.Web.Host.Validators.Slider;
using TaTava.Web.Host.Validators.User;

namespace TaTava.Web.Host.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRegisterApplication(this IServiceCollection services)
        {
            services.RegisterApplicationRequirements();
            services.AddHttpContextAccessor();
            services.AddRegisterFluentValidation();

            services.AddScoped<IJwtGenerator, JwtGenerator>();

            return services;
        }
        public static IServiceCollection AddRegisterFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidator<LoginInput, LoginInputValidator>();
            services.AddFluentValidator<RegisterInput, RegisterInputValidator>();
            services.AddFluentValidator<InsertUserInput, InsertUserInputValidator>();

            services.AddFluentValidator<InsertCategoryInputDto, InsertCategoryInputValidator>();
            services.AddFluentValidator<UpdateCategoryInputDto, UpdateCategoryInputValidator>();

            services.AddFluentValidator<InsertPostInputDto, InsertPostInputValidator>();
            services.AddFluentValidator<UpdatePostInputDto, UpdatePostInputValidator>();

            services.AddFluentValidator<InsertTagInputDto, InsertTagInputValidator>();
            services.AddFluentValidator<UpdateTagInputDto, UpdateTagInputValidator>();

            services.AddFluentValidator<InsertMenuInputDto, InsertMenuInputValidator>();
            services.AddFluentValidator<UpdateMenuInputDto, UpdateMenuInputValidator>();

            services.AddFluentValidator<InsertSliderInputDto, InsertSliderInputValidator>();
            services.AddFluentValidator<UpdateSliderInputDto, UpdateSliderInputValidator>();

            return services;
        }
    }
}