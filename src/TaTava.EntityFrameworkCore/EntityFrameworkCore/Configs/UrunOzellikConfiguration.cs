using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaTava.EntityFrameworkCore.Configs;
using TaTava.Urunler.UrunOzellikleri;

namespace TaTava.EntityFrameworkCore.EntityFrameworkCore.Configs
{
    public class UrunOzellikConfiguration : EntityConfiguration<UrunOzellik, int>
    {
        public override void Configure(EntityTypeBuilder<UrunOzellik> builder)
        {
            builder.Property(urunOzellik => urunOzellik.OzellikAdi)
                .HasColumnType("nvarchar(75)")
                .HasMaxLength(75)
                .IsRequired();

            base.Configure(builder);
        }
    }
}