using Microsoft.Extensions.DependencyInjection;
using TaTava.Application.Shared.Authorization.UserAccounts;
using TaTava.Categories;
using TaTava.Authentication;
using TaTava.Authentications.UserAccounts;
using TaTava.Authentications.Users;
using TaTava.Authorization.UserAccounts;
using TaTava.Authorization.Users;
using TaTava.Content.Categories;
using TaTava.Core.Security;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.EntityFrameworkCore.Repositories;
using TaTava.EntityFrameworkCore.UnitOfWork;
using TaTava.Content.Posts;
using TaTava.Content.PostsCategories;
using TaTava.Application.Content.PostsCategories;
using TaTava.Content.Tags;
using TaTava.Content.PostsTags;
using TaTava.Menus;
using TaTava.Sliders;
using TaTava.Firmalar.Sektorler;
using TaTava.Application.Firmalar.Sektorler;
using TaTava.Urunler;
using TaTava.Firmalar;
using TaTava.Firmalar.Teklifler;
using TaTava.Firmalar.TeklifDetaylari;

namespace TaTava.Application.Infrastructure
{
    public static class ServiceCollection
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            //TODO: Servisler Buraya Kayit Edilecek
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IUserAccountAppService, UserAccountAppService>();
            services.AddTransient<ICategoryAppService, CategoryAppService>();
            services.AddTransient<IPostAppService, PostAppService>();
            services.AddTransient<IPostCategoryAppService, PostCategoryAppService>();
            services.AddTransient<ITagAppService, TagAppService>();
            services.AddTransient<IPostTagAppService, PostTagAppService>();
            services.AddTransient<IMenuAppService, MenuAppService>();
            services.AddTransient<ISliderAppService, SliderAppService>();
            services.AddTransient<ISektorAppService, SektorAppService>();
            services.AddTransient<IUrunAppService, UrunAppService>();
            services.AddTransient<IFirmaAppService, FirmaAppService>();
            services.AddTransient<ITeklifAppService, TeklifAppService>();
            services.AddTransient<ITeklifDetayAppService, TeklifDetayAppService>();



            services.AddScoped<IEncryption, Encryption>();

            return services;
        }

        private static void RegisterApplicationPolicies(this IServiceCollection services)
        {
            services.AddTransient<UserAccountPolicy>();
            services.AddTransient<UserPolicy>();
            services.AddTransient<CategoryPolicy>();
            services.AddTransient<PostPolicy>();
            services.AddTransient<PostCategoryPolicy>();
            services.AddTransient<TagPolicy>();
            services.AddTransient<PostTagPolicy>();
            services.AddTransient<MenuPolicy>();
            services.AddTransient<SliderPolicy>();
        }

        public static void RegisterApplicationRequirements(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, SqlUnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));
            services.AddScoped(typeof(IRepository<,>), typeof(SqlRepository<,>));

            services.RegisterApplicationServices();
            services.RegisterApplicationPolicies();
        }
    }
}