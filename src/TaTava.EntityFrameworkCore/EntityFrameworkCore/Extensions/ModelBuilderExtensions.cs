using Microsoft.EntityFrameworkCore;
using TaTava.EntityFrameworkCore.Configs;
using TaTava.EntityFrameworkCore.EntityFrameworkCore.Configs;

namespace TaTava.EntityFrameworkCore.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder AddEntityMappings(this ModelBuilder modelBuilder)
        {
            #region - System Configuration

            modelBuilder.ApplyConfiguration(new RoleClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            #endregion

            #region - CRM / CMS Entities


            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PostCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new PostTagConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new SliderConfiguration());
            modelBuilder.ApplyConfiguration(new UrunOzellikConfiguration());
            modelBuilder.ApplyConfiguration(new FirmaOzellikUrunConfiguration());
            

            #endregion

            #region - Product Configuration

            // modelBuilder.ApplyConfiguration(new ProductMenuItemConfiguration());
            // modelBuilder.ApplyConfiguration(new ProductMenuConfiguration());
            // modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            // modelBuilder.ApplyConfiguration(new ProductConfiguration());
            // modelBuilder.ApplyConfiguration(new DiscountConfiguration());
            // modelBuilder.ApplyConfiguration(new OrderConfiguration());

            #endregion



            return modelBuilder;
        }

    }
}