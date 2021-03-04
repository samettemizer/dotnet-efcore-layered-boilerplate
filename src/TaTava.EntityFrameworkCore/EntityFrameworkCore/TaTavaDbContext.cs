using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TaTava.Attachments;
using TaTava.Authorization.RoleClaims;
using TaTava.Authorization.Roles;
using TaTava.Authorization.UserAccounts;
using TaTava.Authorization.UserRoles;
using TaTava.Authorization.Users;
using TaTava.Categories;
using TaTava.Content.Posts;
using TaTava.Content.PostsCategories;
using TaTava.Content.PostsTags;
using TaTava.Content.Tags;
using TaTava.EntityFrameworkCore.Extensions;
using TaTava.Firmalar;
using TaTava.Firmalar.FirmaUrunleri;
using TaTava.Firmalar.FirmaUrunOzellikleri;
using TaTava.Firmalar.Sektorler;
using TaTava.Firmalar.TeklifDetaylari;
using TaTava.Firmalar.Teklifler;
using TaTava.Lokasyonlar.Ilceler;
using TaTava.Lokasyonlar.Iller;
using TaTava.Menus;
using TaTava.Sliders;
using TaTava.Urunler;
using TaTava.Urunler.UrunKategorileri;
using TaTava.Urunler.UrunOzellikleri;

namespace TaTava.EntityFrameworkCore
{
    public class TaTavaDbContext : TaTavaCoreDbContext
    {
        public TaTavaDbContext(DbContextOptions<TaTavaDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options, httpContextAccessor)
        {
        }

        #region - System Entities

        public virtual DbSet<RoleClaim> RoleClaims { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        #endregion

        #region - CRM / CMS Entities
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<PostCategory> PostCategories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<PostTag> PostTags { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }

        #endregion

        #region - Reklam Ailesi 

        public virtual DbSet<Firma> Firmalar { get; set; }
        public virtual DbSet<FirmaUrun> FirmaUrunleri { get; set; }
        public virtual DbSet<FirmaUrunOzellik> FirmaUrunOzellikleri { get; set; }
        public virtual DbSet<Teklif> Teklifler { get; set; }
        public virtual DbSet<TeklifDetay> TeklifDetaylari { get; set; }
        public virtual DbSet<Sektor> Sektorler { get; set; }

        public virtual DbSet<Il> Iller { get; set; }
        public virtual DbSet<Ilce> Ilceler { get; set; }

        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<UrunKategori> UrunKategorileri { get; set; }
        public virtual DbSet<UrunOzellik> UrunOzellikleri { get; set; }



        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityMappings();

            base.OnModelCreating(modelBuilder);
        }

    }
}