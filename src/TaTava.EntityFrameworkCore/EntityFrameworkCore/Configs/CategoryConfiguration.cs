using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaTava.Categories;

namespace TaTava.EntityFrameworkCore.Configs
{
    public class CategoryConfiguration : EntityConfiguration<Category, Guid>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(category => category.Title)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            base.Configure(builder);
        }
    }
}