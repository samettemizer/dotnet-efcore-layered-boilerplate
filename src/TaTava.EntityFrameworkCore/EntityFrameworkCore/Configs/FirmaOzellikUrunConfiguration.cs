using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaTava.EntityFrameworkCore.Configs;
using TaTava.Firmalar.FirmaUrunOzellikleri;

namespace TaTava.EntityFrameworkCore.EntityFrameworkCore.Configs
{
    public class FirmaOzellikUrunConfiguration : EntityConfiguration<FirmaUrunOzellik, long>
    {
        public override void Configure(EntityTypeBuilder<FirmaUrunOzellik> builder)
        {
            builder.Property(firmaUrunOzellik => firmaUrunOzellik.Detay)
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);

            builder.Property(firmaUrunOzellik => firmaUrunOzellik.OzellikTuru)
                .IsRequired();

            builder.Property(firmaUrunOzellik => firmaUrunOzellik.FirmaId)
                .HasColumnType("int")
                .IsRequired();
            
            builder.Property(firmaUrunOzellik => firmaUrunOzellik.UrunId)
                .HasColumnType("int")
                .IsRequired();
            
            builder.Property(firmaUrunOzellik => firmaUrunOzellik.UrunOzellikId)
                .HasColumnType("int")
                .IsRequired();

            base.Configure(builder);
        }
    }
}