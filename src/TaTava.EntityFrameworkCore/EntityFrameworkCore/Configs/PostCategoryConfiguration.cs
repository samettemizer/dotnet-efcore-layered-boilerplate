using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Content.PostsCategories;

namespace TaTava.EntityFrameworkCore.Configs
{
    public class PostCategoryConfiguration: EntityConfiguration<PostCategory,Guid>
    {
        public override void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.HasKey(key => new { key.PostId, key.CategoryId });

            builder.Property(postCategory => postCategory.PostId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(postCategory => postCategory.CategoryId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.HasOne(p => p.Post)
                .WithMany(pc => pc.postCategories)
                .HasForeignKey(pc => pc.PostId);

            builder.HasOne(c => c.Category)
                .WithMany(pc => pc.postCategories)
                .HasForeignKey(pc => pc.CategoryId);

            base.Configure(builder);
        }
    }
}
